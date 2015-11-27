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
        private readonly IDictionary<TKey, ICacheEntry<TKey, TValue>> entries;
        private readonly ICachePolicy<TKey, TValue> policy;

        public Cache(IDictionary<TKey, ICacheEntry<TKey, TValue>> entries, ICachePolicy<TKey, TValue> policy, long totalCapacity)
        {
            this.policy = policy;
            this.totalCapacity = totalCapacity;
            this.entries = entries;
        }

        public TValue this[TKey key]
        {
            get
            {
                return entries[key].Value;
            }
            set
            {
                //check if we've reached capacity and need to purge one entry before adding a new one
                //thread safety: check and increment in different operations are OK in this case as 
                //concurrent threads will do add->remove sequentially which will maintain capacity
                //this is safe because the cache doesn't support a Delete operation
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
            }
        }

        public bool ContainsKey(TKey key)
        {
            return entries.ContainsKey(key);
        }
    }
}