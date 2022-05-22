using System;
using System.Collections.Generic;
using System.Text;

class Game
{
    private Deck deck = new Deck();
    private Dealer dealer = new Dealer();
    private Player[] players;

    public Game(Player[] players) 
    {
        this.players = players;
    }
}
