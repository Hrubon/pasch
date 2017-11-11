using System.IO;
using System.Text;


public class FingerprintStore
{
    string storeFile;



    public string PrintFingerprint(byte[] fingerprint)
    {
        var str = new StringBuilder();
        foreach (byte b in fingerprint)
        {
            str.AppendFormat("{0:X2}:", b);
        }
        str.Remove(str.Length - 1, 1);

        return str.ToString();
    }


    public bool IsKnownFingerprint(byte[] fingerprint)
    {
        string str = PrintFingerprint(fingerprint);
        foreach (string line in File.ReadAllLines(storeFile))
        {
            if (line == str)
                return true;
        }
        return false;
    }


    public void AddFingerPrint(byte[] fingerprint)
    {
        string str = PrintFingerprint(fingerprint);
        File.AppendAllLines(storeFile, new[] { str });
    }



    public FingerprintStore(string storeFile)
    {
        this.storeFile = storeFile;

        if (!File.Exists(storeFile))
        {
            var file = File.Create(storeFile);
            file.Close();
        }
    }
}