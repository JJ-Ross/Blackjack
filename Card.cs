public class Card
{
    public string Label { get; private set; }
    public int Value;

    public Card(int value)
    {
        Label = value.ToString();
        Value = value;
    }

    public Card(string label)
    {
        Label = label;
        Value = 10;
    }

    public void FlipAce()
    {
        if (Label.Equals("Ace"))
        {
            Value = 1;
        }
    }
}
