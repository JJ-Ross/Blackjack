using System;
using System.Net.Sockets;
using System.Threading;

public class Client
{
    static void Main()
    {
        Socket socket = Networking.Connect("25.71.64.214", 8080);
        while (true)
        {
            Console.WriteLine(RPC.MakeRPC(socket, new RPC(0, "{ 'text': 'testText' }")));
            Thread.Sleep(1000);
        }
    }
}