using System;


public struct CacheEntry<T>
{
    public User User { get; private set; }
    public DateTime Timestamp { get; private set; }
    public T Item { get; private set; }



    public CacheEntry(User user, DateTime timestamp, T item)
    {
        User = user;
        Timestamp = timestamp;
        Item = item;
    }
}