using System;


[Serializable]
public class AlterBroadcastResponse : Response
{
    public override int Code
    {
        get
        {
            return 201;
        }
    }
    public AlterBroadcastResult Result { get; private set; }



    public AlterBroadcastResponse(AlterBroadcastResult result)
    {
        Result = result;
    }
}