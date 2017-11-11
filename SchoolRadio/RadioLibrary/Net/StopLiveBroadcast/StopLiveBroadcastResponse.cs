using System;


[Serializable]
public class StopLiveBroadcastResponse : Response
{
    public override int Code
    {
        get
        {
            return (int)Result;
        }
    }
    public StopLiveBroadcastResults Result { get; private set; }
    public string Error { get; private set; }



    public StopLiveBroadcastResponse(StopLiveBroadcastResults result, string error = null)
    {
        Result = result;
        Error = error;
    }
}