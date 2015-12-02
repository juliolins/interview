namespace TheTradeDesk.Caching
{
    /// <summary>
    /// Defines an interface for cache mechanisms.
    /// </summary>
    public interface ICache<TKey, TValue>
    {
        /// <summary>
        /// Returns true if a key is present in the cache.
        /// </summary>
        bool ContainsKey(TKey key);

        /// <summary>
        /// Provides key-indexed access to resources stored in the cache.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">key is null</exception>
        /// <exception cref="System.ArgumentException">An element with the same key already exists</exception>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">The property is retrieved and key is not found</exception>
        TValue this[TKey key] { get; set; }

        /// <summary>
        /// Removes an element from the dictionary.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">key is null</exception>
        bool Remove(TKey key);
    }

    /// <summary>
    /// Adds the method Add() and Get() to the ICache interface.
    /// </summary>
    public static class ICacheExtensions
    {
        /// <summary>
        /// Adds a new element.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">key is null</exception>
        /// <exception cref="System.ArgumentException">An element with the same key already exists</exception>
        public static void Add<TKey, TValue>(this ICache<TKey, TValue> cache, TKey key, TValue value) 
        {
            cache[key] = value;
        }

        /// <summary>
        /// Returns an existing element.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">key is null</exception>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">The property is retrieved and key is not found</exception>
        public static TValue Get<TKey, TValue>(this ICache<TKey, TValue> cache, TKey key)
        {
            return cache[key];
        }
    }
}
