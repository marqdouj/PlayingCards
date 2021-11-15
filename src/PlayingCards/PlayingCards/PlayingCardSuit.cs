namespace PlayingCards;

public enum PlayingCardSuit
{
    Spades,
    Hearts,
    Diamonds,
    Clubs
}

public static class PlayingCardSuitExtension
{
    private static readonly char[] characters = new char[] { '♠', '♥', '♦', '♣' };

    public static string CardChar(this PlayingCardSuit suit) => characters[(int)suit].ToString();

    public static string CardText(this PlayingCardSuit suit) => suit.ToString()[0].ToString();
}
