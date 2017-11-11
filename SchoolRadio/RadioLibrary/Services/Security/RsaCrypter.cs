using System.Security.Cryptography;


public class RsaCrpyter : EncryptionProvider
{
    const int KEY_SIZE = 4096;



    RSACryptoServiceProvider provider;



    public override byte[] Key
    {
        get
        {
            return provider.ExportPublicKey();
        }
    }



    public override byte[] Encrypt(byte[] data)
    {
        return provider.Encrypt(data, false);
    }


    public override byte[] Decrypt(byte[] data)
    {
        return provider.Decrypt(data, false);
    }



    public RsaCrpyter StripPrivateKey()
    {
        string xml = provider.ToXmlString(false);
        return new RsaCrpyter(xml);
    }


    public string GetPublicXmlConfig()
    {
        return provider.ToXmlString(false);
    }


    public string GetFullXmlConfig()
    {
        return provider.ToXmlString(true);
    }



    public RsaCrpyter()
    {
        provider = new RSACryptoServiceProvider(KEY_SIZE);
    }

    public RsaCrpyter(string xmlConfig)
    {
        provider = new RSACryptoServiceProvider(KEY_SIZE);
        provider.FromXmlString(xmlConfig);
    }
}