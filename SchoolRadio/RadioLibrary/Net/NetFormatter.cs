using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


public class NetFormatter
{
    private byte[] Serialize(object graph)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream();
        formatter.Serialize(stream, graph);
        stream.Seek(0, SeekOrigin.Begin);
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);

        return buffer;
    }


    private object Deserialize(byte[] buffer)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream(buffer);
        object graph = formatter.Deserialize(stream);

        return graph;
    }



    public byte[] Format(Request request)
    {
        return Serialize(request);
    }


    public byte[] Format(Response response)
    {
        return Serialize(response);
    }


    public Request GetRequest(byte[] buffer)
    {
        return (Request)Deserialize(buffer);
    }


    public Response GetResponse(byte[] buffer)
    {
        return (Response)Deserialize(buffer);
    }
}