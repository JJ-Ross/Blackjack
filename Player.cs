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
        if (total > 21)
        {
            foreach (Card card in Hand)
            {
                if (card.Value == 11)
                {
                    card.Value = 1;
                    if (GetTotal() <= 21) break;
                }
            }
        }
        return total;
    }
}