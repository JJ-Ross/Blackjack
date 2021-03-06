using System;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json.Linq;

public class Client
{
    static void Main()
    {
        Socket socket = Networking.Connect("25.71.64.64", 8080);
        int playerID = int.Parse(Networking.Receive(socket));
        Networking.Receive(socket); //Wait for game to start
        while (true)
        {
            Console.WriteLine(RPC.MakeRPC(socket, new RPC(0, "")));
            Thread.Sleep(1000);
        }
    }
}