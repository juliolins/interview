using System;
using System.Collections.Generic;

namespace TheTradeDesk.Caching
{
    /// <summary>
    /// Implements a cache mechanism using the provided cache policy and IDictionary.
    /// The provided policy implementations in this package offer constant time performance.
    /// 
    /// The current implementation assumes an uniform hashing algorithm for the key for its constant time.
    /// Future versions could encapsulate the key within another object with a well-known uniform hashing function
    /// (based off the key value).
    /// </summary>
    /// 
    /// <remarks>
    ///     The cache can be either thread-safe or not depending on the ICacheLock and IDictionary implementation.
    /// </remarks>
    public class Cache<TKey, TValue> : ICache<TKey, TValue>
    {
        private readonly long totalCapacity;
        private readonly IDictionary<TKey, ICacheEntry<TKey, TValue>> entries = new Dictionary<TKey, ICacheEntry<TKey, TValue>>();
        private readonly ICachePolicy<TKey, TValue> policy;
        private readonly ICacheLock cacheLock;

        public Cache(ICachePolicy<TKey, TValue> policy, ICacheLock cacheLock, long totalCapacity)
        {
            this.policy = policy;
            this.cacheLock = cacheLock;
            this.totalCapacity = totalCapacity;
        }

        public bool ContainsKey(TKey key)
        {
            return FunctionWithinLock<bool>(() => entries.ContainsKey(key));
        }

        public TValue this[TKey key]
        {
            get
            {
                return FunctionWithinLock<TValue>(() => 
                {
                    var entry = entries[key];
                    policy.Hit(entry); //New 1.01: bug fix from the initial version. Missed calling policy.Hit()
                    return entry.Value;
                });
            }
            set
            {
                ActionWithinLock(() =>
                {
                    if (entries.Count >= totalCapacity)
                    {
                        //ask the policy which entry to remove
                        TKey purgedKey = default(TKey);
                        if (policy.Purge(out purgedKey))
                        {
                            entries.Remove(purgedKey);
                        }
                    }

                    //create a new entry and add it
                    var newEntry = policy.NewEntry(key, value);
                    entries.Add(key, newEntry);
                });
            }
        }

        public bool Remove(TKey key)
        {
            return FunctionWithinLock<bool>(() =>
            {
                //returns true if the key existed in the dictionary
                bool deleteOk = entries.ContainsKey(key);
                if (deleteOk)
                {
                    var entry = entries[key];
                    policy.Delete(entry);
                    entries.Remove(key);
                }

                return deleteOk;
            });            
        }

        /// <summary>
        /// Helper method to assure a block of code is run within the scope of the ICacheLock.
        /// </summary>
        private void ActionWithinLock(Action action)
        {
            try
            {
                cacheLock.Wait();
                action();
            }
            finally
            {
                cacheLock.Release();
            }
        }

        /// <summary>
        /// Helper method to assure a block of code is run within the scope of the ICacheLock.
        /// </summary>
        private T FunctionWithinLock<T>(Func<T> function)
        {
            try
            {
                cacheLock.Wait();
                return function();
            }
            finally
            {
                cacheLock.Release();
            }
        }
    }
}