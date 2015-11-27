using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTradeDesk.Caching
{
    /// <summary>
    /// Distributes requests among a collection of caches to reduce the lock wait time when accessing the cache.
    /// Experimental idea for high concurrency and high capacity scenarios with many threads accessing the same cache.
    /// All operations on the 'cacheMap' array are read-only after the constructor so this class is thread safe.
    /// 
    /// ** Let's consider this class as not part of the actual implementation but an idea to be discussed later **
    /// </summary>
    public class CompositeCache<TKey, TValue> : ICache<TKey, TValue>
    {
        private readonly ICache<TKey, TValue>[] cacheMap;

        /// <summary>
        /// Creates a composite cache using the existing cache instances.
        /// The number of instances should be a prime number to improve the
        /// chances of an even distribution of requests.
        /// </summary>
        public CompositeCache(IEnumerable<ICache<TKey, TValue>> caches)
        {
            this.cacheMap = caches.ToArray();
        }

        private ICache<TKey, TValue> GetCache(TKey key)
        {
            int index = (key.GetHashCode() & 0x7fffffff) % cacheMap.Length;
            return cacheMap[index];
        }

        public bool ContainsKey(TKey key)
        {
            return GetCache(key).ContainsKey(key);
        }

        public TValue this[TKey key]
        {
            get
            {
                return GetCache(key)[key];
            }
            set
            {
                GetCache(key)[key] = value;
            }
        }
    }
}
