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
        /// Existing values are overwritten.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">key is null</exception>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">The property is retrieved and key is not found</exception>
        TValue this[TKey key] { get; set; }
    }
}
