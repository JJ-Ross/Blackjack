public class Card
{
    public string Label { get; private set; }
    public int Value { get; private set; }

    public Card(int value)
    {
        Label = value.ToString();
        Value = value;
    }

    public Card(string label)
    {
        Label = label;
        Value = label.Equals("Ace") ? 1 : 10;
    }

    public void FlipAce()
    {
        if (Label.Equals("Ace"))
        {
            Value = Value == 1 ? 11 : 1;
        }
    }
}
