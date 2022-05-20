using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Server
{
    public static List<Func<string, string>> Operations = new List<Func<string, string>>();

    static void Main()
    {
        PopulateOperations();
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 8080);
        Socket listener = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        listener.Bind(localEndPoint);
        listener.Listen(128);
        while (true)
        {
            Console.WriteLine("Waiting for connection...");
            Socket player = listener.Accept();
            Console.WriteLine("Player connected from " + player.RemoteEndPoint);
            new Thread(() =>
            {
                while (true)
                {
                    RPC call = JsonConvert.DeserializeObject<RPC>(Networking.Receive(player));
                    Networking.Send(player, Operations[call.Opcode](call.Json));
                }
            }).Start();
        }
    }

    private static void PopulateOperations()
    {
        Operations.Add((string x) => "Test: " + x);
    }
}