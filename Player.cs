using System.Collections.Generic;
using System.Net.Sockets;

public class Player
{
    public List<Card> Hand = new List<Card>();
    private Socket connection;

    public Player(Socket connection)
    {
        this.connection = connection;
    }

    public int GetTotal()
    {
        int total = 0;
        foreach (Card card in Hand)
        {
            total += card.Value;
        }
        return total;
    }
}