using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTradeDesk.Caching.Policy;

namespace TheTradeDesk.Caching
{
    /// <summary>
    /// Builds out of box cache configurations.
    /// </summary>
    public static class CacheBuilder
    {
        /// <summary>
        /// Returns a thread safe LRU implementation.
        /// </summary>
        public static ICache<TKey, TValue> LRU_ThreadSafe<TKey, TValue>(int totalCapacity)
        {
            return LRU(new ConcurrentDictionary<TKey, ICacheEntry<TKey, TValue>>(), new SemaphoreWriteLock(), totalCapacity);
        }

        /// <summary>
        /// Returns a LRU implementation intended for single thread use.
        /// </summary>
        public static ICache<TKey, TValue> LRU_NonThreadSafe<TKey, TValue>(int totalCapacity)
        {
            return LRU(new Dictionary<TKey, ICacheEntry<TKey, TValue>>(), new NoOpLock(), totalCapacity);
        }

        /// <summary>
        /// Returns a Least Recently Used (LRU) cache policy.
        /// </summary>
        public static ICachePolicy<TKey, TValue> LRU_Policy<TKey, TValue>(ICacheLock cacheLock)
        {
            return new LinkedListCachePolicy<TKey, TValue>(cacheLock, (list) => list.Last); //chooses the tail of the list
        }

        private static ICache<TKey, TValue> LRU<TKey, TValue>(IDictionary<TKey, ICacheEntry<TKey, TValue>> entries, ICacheLock cacheLock, int totalCapacity)
        {
            return new Cache<TKey, TValue>(
                entries,
                LRU_Policy<TKey, TValue>(cacheLock),
                totalCapacity);
        }

        /// <summary>
        /// Returns a thread safe MRU implementation.
        /// </summary>
        public static ICache<TKey, TValue> MRU_ThreadSafe<TKey, TValue>(int totalCapacity)
        {
            return MRU(new ConcurrentDictionary<TKey, ICacheEntry<TKey, TValue>>(), new SemaphoreWriteLock(), totalCapacity);
        }

        /// <summary>
        /// Returns a MRU implementation intended for single thread use.
        /// </summary>
        public static ICache<TKey, TValue> MRU_NonThreadSafe<TKey, TValue>(int totalCapacity)
        {
            return MRU(new Dictionary<TKey, ICacheEntry<TKey, TValue>>(), new NoOpLock(), totalCapacity);
        }

        /// <summary>
        /// Returns a Least Recently Used (LRU) cache policy.
        /// </summary>
        public static ICachePolicy<TKey, TValue> MRU_Policy<TKey, TValue>(ICacheLock cacheLock)
        {
            return new LinkedListCachePolicy<TKey, TValue>(cacheLock, (list) => list.First); //chooses the head of the list
        }

        private static ICache<TKey, TValue> MRU<TKey, TValue>(IDictionary<TKey, ICacheEntry<TKey, TValue>> entries, ICacheLock cacheLock, int totalCapacity)
        {
            return new Cache<TKey, TValue>(
                entries,
                MRU_Policy<TKey, TValue>(cacheLock),
                totalCapacity);
        }
    }
}
