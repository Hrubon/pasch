using System;


[Serializable]
public class SelectBroadcastResponse : Response
{
    public override int Code { get { return 201; } }
    public BroadcastInfo[] Broadcasts { get; private set; }



    public SelectBroadcastResponse(BroadcastInfo[] broadcasts)
    {
        Broadcasts = broadcasts;
    }
}