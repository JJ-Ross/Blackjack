using System.Net;
using System.Net.Sockets;
using System.Text;

public static class Networking
{
    public static Socket Connect(string ip, int port)
    {
        IPAddress ipAddress = IPAddress.Parse(ip);
        IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
        Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(remoteEP);
        return socket;
    }

    public static void Send(Socket socket, string data)
    {
        socket.Send(Encoding.ASCII.GetBytes(data + '\0'));
    }

    private static string spillover = "";
    public static string Receive(Socket socket)
    {
        byte[] buffer = new byte[1024];
        int bytesRead = socket.Receive(buffer);
        string data = spillover + Encoding.ASCII.GetString(buffer, 0, bytesRead);
        int i = data.IndexOf('\0');
        if (i == -1)
        {
            spillover = data;
            return Receive(socket);
        }
        spillover = data.Length > i + 1 ? data[(i + 1)..] : "";
        data = data[..i];
        return data;
    }
}