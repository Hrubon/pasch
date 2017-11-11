using System;
using System.IO;
using System.Security.Cryptography;


public class AesCrypter : EncryptionProvider
{
    AesManaged provider;



    public override byte[] Key
    {
        get
        {
            return provider.Key;
        }
    }
    public byte[] IV
    {
        get
        {
            return provider.IV;
        }
    }



    public override byte[] Encrypt(byte[] data)
    {
        ICryptoTransform encryptor = provider.CreateEncryptor();
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(data, 0, data.Length);
        cryptoStream.FlushFinalBlock();

        byte[] buffer = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();

        return buffer;
    }


    public override byte[] Decrypt(byte[] data)
    {
        ICryptoTransform decryptor = provider.CreateDecryptor();
        MemoryStream memoryStream = new MemoryStream(data);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

        byte[] buffer = new byte[data.Length];
        int decryptedByteCount = cryptoStream.Read(buffer, 0, buffer.Length);
        memoryStream.Close();
        cryptoStream.Close();

        byte[] output = new byte[decryptedByteCount];
        Array.Copy(buffer, output, output.Length);

        return output;
    }



    public AesCrypter()
    {
        provider = new AesManaged();
        provider.GenerateKey();
        provider.IV = new byte[provider.BlockSize / 8];
        provider.Padding = PaddingMode.Zeros;
    }


    public AesCrypter(byte[] key)
    {
        provider = new AesManaged();
        provider.Key = key;
        provider.IV = new byte[provider.BlockSize / 8];
        provider.Padding = PaddingMode.Zeros;
    }
}