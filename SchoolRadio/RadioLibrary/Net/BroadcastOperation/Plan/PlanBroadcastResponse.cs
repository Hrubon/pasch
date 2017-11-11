using System;


[Serializable]
public class PlanBroadcastResponse : Response
{
    public override int Code
    {
        get
        {
            return (int)Result;
        }
    }
    public PlanBroadcastResult Result { get; private set; }



    public PlanBroadcastResponse(PlanBroadcastResult result, BroadcastInfo[] collisions)
    {
        Result = result;
    }
}