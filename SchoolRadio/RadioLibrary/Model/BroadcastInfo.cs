using System;


[Serializable]
public class BroadcastInfo
{
    public int Id { get; internal set; }
    public string Username { get; private set; }
    public DateTime StartTime { get; private set; }
    public TimeSpan Duration { get; private set; }
    public DateTime EndTime
    {
        get
        {
            return StartTime.Add(Duration);
        }
    }
    public string Label { get; private set; }
    public BroadcastType Type { get; private set; }
    public MediaType MediaType { get; private set; }
    public string Filename { get; set; }



    public BroadcastInfo(string username, DateTime startTime, TimeSpan duration, BroadcastType type, MediaType mediaType, string label = "")
    {
        Username = username;
        StartTime = startTime;
        Duration = duration;
        Type = type;
        MediaType = mediaType;
        Label = label;
    }


    public BroadcastInfo(int id, string username, DateTime startTime, TimeSpan duration, BroadcastType type, MediaType mediaType, string filename, string label = "")
    {
        Id = id;
        Username = username;
        StartTime = startTime;
        Duration = duration;
        Type = type;
        Label = label;
        Filename = filename;
    }
}