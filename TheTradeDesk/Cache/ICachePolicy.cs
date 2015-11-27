
namespace TheTradeDesk.Caching
{

    /// <summary>
    /// Represents a cache entry to be maintained by the cache as a
    /// map Tkey -> ICacheEntry<TKey, TValue>.
    /// </summary>
    public interface ICacheEntry<TKey, TValue>
    {
        TKey Key { get; }
        TValue Value { get; }
    }

    /// <summary>
    /// Defines a generic interface for cache policies which will
    /// dictate which entry should be removed from the cache when
    /// a new entry is added at capacity.
    /// </summary>
    public interface ICachePolicy<TKey, TValue>
    {
        ICacheEntry<TKey, TValue> NewEntry(TKey key, TValue value);
        void Hit(ICacheEntry<TKey, TValue> entry);
        bool Purge(out TKey key);
    }
}
