using System;


[Serializable]
public class LiveBroadcastResponse : Response
{
    public override int Code
    {
        get
        {
            return (int)Result;
        }
    }
    public LiveBroadcastResults Result { get; private set; }
    public string Error { get; private set; }



    public LiveBroadcastResponse(LiveBroadcastResults result, string error = null)
    {
        Result = result;
        Error = error;
    }
}