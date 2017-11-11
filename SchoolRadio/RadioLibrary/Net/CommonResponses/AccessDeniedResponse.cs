using System;


[Serializable]
public class AccessDeniedResponse : Response
{
    public override int Code
    {
        get
        {
            return 102;
        }
    }
}