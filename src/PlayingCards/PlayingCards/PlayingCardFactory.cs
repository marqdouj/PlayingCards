namespace PlayingCards;

public static class PlayingCardFactory
{
    private static readonly IReadOnlyDictionary<string, PlayingCard> _cards = CreateCards();

    private static Dictionary<string, PlayingCard> CreateCards()
    {
        var cards = new Dictionary<string, PlayingCard>();
        
        foreach (var rank in Enum.GetValues<PlayingCardRank>())
        {
            foreach (var suit in Enum.GetValues<PlayingCardSuit>())
            {
                var card = new PlayingCard (rank, suit );
                cards.Add(card.Key, card);
            }
        }

        return cards;
    }

    public static IEnumerable<PlayingCard> GetCards() => 
        _cards.Values
        .OrderByDescending(e => e.Suit).ThenByDescending(e => e.Rank)
        .ToList();

    public static PlayingCard GetCard(PlayingCardRank rank, PlayingCardSuit suit) =>
        _cards.First(e => e.Key == GetKey(rank, suit)).Value;

    public static PlayingCard GetCard(this IEnumerable<PlayingCard> cards, PlayingCardRank rank, PlayingCardSuit suit) =>
        cards.First(e => e.Key == GetKey(rank, suit));

    public static IEnumerable<PlayingCard> GetSuit(this IEnumerable<PlayingCard> cards, PlayingCardSuit suit) 
        => cards.Where(e => e.Suit == suit).OrderByDescending(e => e.Rank).ToList();

    public static string GetKey(PlayingCardRank rank, PlayingCardSuit suit) =>
        $"{rank.CardChar()}{suit.CardChar()}";

    public static bool IsSameCard(this PlayingCard cardA, PlayingCard cardB) 
        => (cardA.Key == cardB.Key);

    public static bool IsSameRank(this PlayingCard cardA, PlayingCard cardB)
    => (cardA.Rank == cardB.Rank);

    public static bool IsSameSuit(this PlayingCard cardA, PlayingCard cardB)
    => (cardA.Suit == cardB.Suit);
}
