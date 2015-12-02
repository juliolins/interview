using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static ICachePolicy<TKey, TValue> LRU_Policy<TKey, TValue>()
        {
            return new SortedListCachePolicy<TKey, TValue>((list) => list.Last); //chooses the tail of the list
        }

        private static ICache<TKey, TValue> LRU<TKey, TValue>(IDictionary<TKey, ICacheEntry<TKey, TValue>> entries, ICacheLock cacheLock, int totalCapacity)
        {
            return new Cache<TKey, TValue>(
                LRU_Policy<TKey, TValue>(),
                cacheLock,
                totalCapacity);
        }

        /// <summary>
        /// Returns a thread safe MRU implementation.
        /// </summary>
        public static ICache<TKey, TValue> MRU_ThreadSafe<TKey, TValue>(int totalCapacity)
        {
            return MRU<TKey, TValue>(new SemaphoreWriteLock(), totalCapacity);
        }

        /// <summary>
        /// Returns a MRU implementation intended for single thread use.
        /// </summary>
        public static ICache<TKey, TValue> MRU_NonThreadSafe<TKey, TValue>(int totalCapacity)
        {
            return MRU<TKey, TValue>(new NoOpLock(), totalCapacity);
        }

        /// <summary>
        /// Returns a Least Recently Used (LRU) cache policy.
        /// </summary>
        public static ICachePolicy<TKey, TValue> MRU_Policy<TKey, TValue>()
        {
            return new SortedListCachePolicy<TKey, TValue>((list) => list.First); //chooses the head of the list
        }

        private static ICache<TKey, TValue> MRU<TKey, TValue>(ICacheLock cacheLock, int totalCapacity)
        {
            return new Cache<TKey, TValue>(
                MRU_Policy<TKey, TValue>(),
                cacheLock,
                totalCapacity);
        }

        /// <summary>
        /// Create a SetAssociative cache using the specified number of MRU thread-safe caches (sets), 
        /// each with the specified total capacity (lines).
        /// </summary>
        public static ICache<TKey, TValue> SetAssociative_MRU<TKey, TValue>(int sets, int lines)
        {
            var caches = Enumerable.Range(0, sets).Select(i => MRU_ThreadSafe<TKey, TValue>(lines));
            return new SetAssociativeCache<TKey, TValue>(caches);
        }

        /// <summary>
        /// Create a SetAssociative cache using the specified number of LRU thread-safe caches (sets), 
        /// each with the specified total capacity (lines).
        /// </summary>
        public static ICache<TKey, TValue> SetAssociative_LRU<TKey, TValue>(int sets, int lines)
        {
            var caches = Enumerable.Range(0, sets).Select(i => LRU_ThreadSafe<TKey, TValue>(lines));
            return new SetAssociativeCache<TKey, TValue>(caches);
        }
    }
}
