using System;
using System.IO;
using System.Reflection;


public class FileStore
{
    public string PathRoot { get; private set; }



    public string GetFilename(BroadcastInfo broadcast)
    {
        string ext = (broadcast.MediaType == MediaType.MP3) ? "mp3" : "wav";
        string dt = broadcast.StartTime.ToString("dd-MM-yyyy-hh-mm-ss");

        return string.Format("{0}-{1}.{2}", dt, broadcast.Username, ext);
    }


    public string GetFullFilename(BroadcastInfo broadcast)
    {
        return Path.Combine(PathRoot, broadcast.Filename);
    }


    public string GenerateFullFilename(BroadcastInfo broadcast)
    {
        string filename = GetFilename(broadcast);

        return Path.Combine(PathRoot, filename);
    }


    public bool FileExists(string filename)
    {
        return File.Exists(GetFullPath(filename));
    }


    public void Delete(string filename)
    {
        string fullPath = GetFullPath(filename);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }



    private string GetFullPath(string filename)
    {
        return Path.Combine(PathRoot, filename);
    }


    private string GetAssemblyDir()
    {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);

        return Path.GetDirectoryName(path);
    }


    public FileStore(string pathRoot)
    {
        if (!Path.IsPathRooted(pathRoot))
            pathRoot = Path.Combine(GetAssemblyDir(), pathRoot);

        if (!Directory.Exists(pathRoot))
            Directory.CreateDirectory(pathRoot);

        PathRoot = pathRoot;
    }
}