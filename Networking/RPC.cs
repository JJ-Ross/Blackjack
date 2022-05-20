using Newtonsoft.Json;
using System.Net.Sockets;

public class RPC
{
    public int Opcode;
    public string Json;

    public RPC(int opcode, string json)
    {
        Opcode = opcode;
        Json = json;
    }

    public static string MakeRPC(Socket socket, RPC call)
    {
        Networking.Send(socket, JsonConvert.SerializeObject(call));
        return Networking.Receive(socket);
    }
}