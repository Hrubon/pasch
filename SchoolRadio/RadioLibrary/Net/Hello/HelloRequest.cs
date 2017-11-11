using System;


[Serializable]
public class HelloRequest : Request
{
    public override bool RequiresAuthentication
    {
        get
        {
            return false;
        }
    }
    public override bool RequiresAuthorization
    {
        get
        {
            return false;
        }
    }



    public override Response Execute()
    {
        var crypter = MasterContainer.GetService<RsaCrpyter>();
        var clientCripter = crypter.StripPrivateKey();

        return new HelloResponse(clientCripter.GetPublicXmlConfig());
    }



    public HelloRequest() : base(User.None)
    {
    }
}