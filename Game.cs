using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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

    public string HitRPC(string json)
    {
        Player player = JsonConvert.DeserializeObject<Player>(json);
        Card popCard = deck.Pop();
        player.Hand.Add(popCard);
        if (++CurrentPlayer >= players.Length) CurrentPlayer = 0;
        return JsonConvert.SerializeObject(popCard);
    }

    public string StandRPC(string ignore)
    {
        if (++CurrentPlayer >= players.Length) CurrentPlayer = 0;
        return null;
    }
}
