using System.Collections.Generic;
using System.Net.Sockets;

class Player
{
    private List<Card> hand = new List<Card>();
    private Socket connection;

    public Player(Socket connection)
    {
        this.connection = connection;
    }

    public int GetTotal()
    {
        int total = 0;
        foreach (Card card in hand)
        {
            total += card.Value;
        }
        return total;
    }
}