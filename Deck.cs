using System;

public class Deck
{
    private readonly Card[] cards = new Card[52];
    private int top = 0;

    public Deck()
    {
        for (int i = 0, j = 0; i < 4; ++i)
        {
            for (int k = 2; k <= 10; ++k, ++j)
            {
                cards[j] = new Card(k);
            }
            cards[j++] = new Card("Jack");
            cards[j++] = new Card("Queen");
            cards[j++] = new Card("King");
            cards[j++] = new Card("Ace");
        }
        Shuffle();
    }

    public void Shuffle()
    {
        Random rand = new Random();
        for (int i = 51; i > 0; --i)
        {
            int res = rand.Next(0, i + 1);
            Card temp = cards[res];
            cards[res] = cards[i];
            cards[i] = temp;
        }
    }

    public Card Pop()
    {
        return top == 52 ? null : cards[top++];
    }
}