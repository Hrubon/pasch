using System;
using System.Data;


public interface IBroadcastDatabase
{
    IDbConnection Connection { get; }

    BroadcastInfo[] GetAll();
    BroadcastInfo[] GetInterval(DateTime start, DateTime end);
    BroadcastInfo GetNowPlaying();

    void Add(BroadcastInfo broadcast);
    bool Edit(int id, DateTime newStartTime, string newLabel);
    bool Remove(int id);
}