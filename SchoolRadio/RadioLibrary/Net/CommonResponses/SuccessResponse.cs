using System;


[Serializable]
public class SuccessResponse : Response
{
    public override int Code
    {
        get
        {
            return 201;
        }
    }
}