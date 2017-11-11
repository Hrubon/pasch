using System;


[Serializable]
public class AuthenticateResponse : Response
{
    public override int Code
    {
        get
        {
            return (int)Result;
        }
    }
    public AuthenticationResult Result { get; private set; }



    public AuthenticateResponse(AuthenticationResult result)
    {
        Result = result;
    }
}