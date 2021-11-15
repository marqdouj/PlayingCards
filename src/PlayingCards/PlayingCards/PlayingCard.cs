namespace PlayingCards;

public record class PlayingCard(PlayingCardRank Rank, PlayingCardSuit Suit)
{
    public string Key { get; init; } = PlayingCardFactory.GetKey(Rank, Suit);

    public string RankChar => Rank.CardChar();

    public string SuitChar => Suit.CardChar();

    public override string ToString() => Key;
}
