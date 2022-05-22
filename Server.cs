using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Server
{
    public static List<Func<string, string>> Operations = new List<Func<string, string>>();
    public static List<Player> Players = new List<Player>();

    static void Main()
    {
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 8080);
        Socket listener = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        listener.Bind(localEndPoint);
        listener.Listen(128);
        new Thread(() =>
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line.Equals("start"))
                {
                    //start new round
                    Game game = new Game(Players.ToArray());
                    Operations.Add(game.UpdateRPC);
                    Operations.Add(game.HitRPC);
                    Operations.Add(game.StandRPC);
                    game.OpeningDeal();
                    break;
                }
            }
        }).Start();
        while (true)
        {
            Console.WriteLine("Waiting for connection...");
            Socket player = listener.Accept();
            Players.Add(new Player(player));
            Networking.Send(player, (Players.Count - 1).ToString());
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
}