using System;
using System.Collections.Generic;
using System.Text;

public class Dealer
{
    public List<Card> Hand = new List<Card>();

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
