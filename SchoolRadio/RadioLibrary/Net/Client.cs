using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;


public class Client
{
    public Task Subthread { get; private set; }
    public TcpClient NetInterface { get; private set; }



    public Client(Task subthread, TcpClient netInterface)
    {
        Subthread = subthread;
        NetInterface = netInterface;
    }
}