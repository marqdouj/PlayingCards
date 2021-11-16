namespace PlayingCards;

public class PlayingCardDeck
{
    public PlayingCardDeck(IEnumerable<PlayingCard>? cards = null)
    {
        cards ??= PlayingCardFactory.GetCards();
        _cards.AddRange(cards);
    }

    private readonly Random _random = new();

    private readonly List<PlayingCard> _cards = new();
    public IReadOnlyList<PlayingCard> Cards => _cards;

    public PlayingCard? GetCard(string key) => _cards.FirstOrDefault(e => e.Key == key);

    public PlayingCard? GetCard(PlayingCardRank rank, PlayingCardSuit suit) =>
        _cards.FirstOrDefault(e => e.Rank == rank && e.Suit == suit);

    public bool HasCard(string key) => _cards.Any(e => e.Key == key);

    public bool HasCard(PlayingCardRank rank, PlayingCardSuit suit) =>
        _cards.Any(e => e.Rank == rank && e.Suit == suit);

    public PlayingCard Deal(int index)
    {
        var card = _cards.ElementAt(index);
        _cards.Remove(card);
        return card;
    }

    public PlayingCard? Peek(int index) => _cards.ElementAtOrDefault(index);

    public void Sort(PlayingCardComparer? comparer = null)
    {
        var oldCards = _cards.ToList();
        var cmp = comparer ?? new PlayingCardComparer();

        oldCards.Sort(cmp);
        UpdateCards(oldCards);
    }

    public void Reset() => UpdateCards(PlayingCardFactory.GetCards());

    public void Shuffle()
    {
        var newCards = new List<PlayingCard>();
        var oldCards = _cards.ToList();

        while (oldCards.Count > 0)
        {
            var cardToMove = _random.Next(oldCards.Count);
            newCards.Add(oldCards[cardToMove]);
            oldCards.RemoveAt(cardToMove);
        }

        UpdateCards(newCards);
    }

    private void UpdateCards(IEnumerable<PlayingCard> cards)
    {
        _cards.Clear();
        _cards.AddRange(cards);
    }
}
