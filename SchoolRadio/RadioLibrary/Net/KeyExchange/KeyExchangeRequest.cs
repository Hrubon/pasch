using System;

[Serializable]
public class KeyExchangeRequest : Request
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
    public byte[] Key { get; private set; }



    public override Response Execute()
    {
        Session.Crpter = new AesCrypter(Key);

        return new SuccessResponse();
    }



    public KeyExchangeRequest(byte[] key) : base(User.None)
    {
        Key = key;
    }
}