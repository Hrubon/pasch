using System.Security.Cryptography;
using System.Text;


public abstract class EncryptionProvider
{
    public abstract byte[] Key{ get; }

    public byte[] KeyFingerprint
    {
        get
        {
            return SHA1.Create().ComputeHash(Key);
        }
    }



    public abstract byte[] Encrypt(byte[] data);
    public abstract byte[] Decrypt(byte[] data);



    public byte[] EncryptString(string data)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(data);

        return Encrypt(buffer);
    }


    public string DecryptString(byte[] data)
    {
        var buffer = Decrypt(data);

        return Encoding.UTF8.GetString(buffer);
    }
}