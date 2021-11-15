namespace PlayingCards;

public record class PlayingCard(PlayingCardRank Rank, PlayingCardSuit Suit)
{
    public string Key { get; init; } = PlayingCardFactory.GetKey(Rank, Suit);

    public override string ToString() => Key;
}
