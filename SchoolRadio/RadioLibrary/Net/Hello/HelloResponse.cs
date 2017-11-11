using System;


[Serializable]
public class HelloResponse : Response
{
    public override int Code
    {
        get
        {
            return 201;
        }
    }
    public string CrypterConfig { get; private set; }



    public HelloResponse(string crpterConfig)
    {
        CrypterConfig = crpterConfig;
    }
}