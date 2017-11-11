using System;


[Serializable]
public class UploadBroadcastResponse : Response
{
    public override int Code
    {
        get
        {
            return (int)Result;
        }
    }
    public UploadBroadcastResult Result { get; private set; }



    public UploadBroadcastResponse(UploadBroadcastResult result)
    {
        Result = result;
    }
}