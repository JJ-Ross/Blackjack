using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Game
{
    public int CurrentPlayer = 0;
    private Deck deck = new Deck();
    private Dealer dealer = new Dealer();
    private Player[] players;

    public Game(Player[] players) 
    {
        this.players = players;
    }

    public void OpeningDeal()
    {
        foreach (Player player in players)
        {
            player.Hand.Add(deck.Pop());
            player.Hand.Add(deck.Pop());
        }
        dealer.Hand.Add(deck.Pop());
        dealer.Hand.Add(deck.Pop());
    }

    private void EndRound()
    {
        int greatestTotal = 0;
        foreach (Player player in players)
        {
            if (player.GetTotal() > greatestTotal)
            {
                greatestTotal = player.GetTotal();
            }
        }
        while (dealer.GetTotal() <= greatestTotal && dealer.GetTotal() < 17)
        {
            dealer.Hand.Add(deck.Pop());
        }
        if (dealer.GetTotal() <= 21) Console.WriteLine("dealer wins");
        else Console.WriteLine("Someone won");
    }

    public string HitRPC(string json)
    {
        Player player = JsonConvert.DeserializeObject<Player>(json);
        Card popCard = deck.Pop();
        player.Hand.Add(popCard);
        return JsonConvert.SerializeObject(popCard);
    }

    public string StandRPC(string ignore)
    {
        if (++CurrentPlayer >= players.Length) EndRound();
        return "";
    }

    public string UpdateRPC(string ignore)
    {
        JObject obj = new JObject();
        obj.Add("currentPlayer", CurrentPlayer);
        return obj.ToString();
    }
}
