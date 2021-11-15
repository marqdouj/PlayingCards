namespace PlayingCards;

public sealed class PlayingCardComparer : IComparer<PlayingCard>
{
    public int Compare(PlayingCard? x, PlayingCard? y)
    {
        int value = 0;

        if (x == null || y == null) throw new ArgumentNullException(nameof(PlayingCard));
        
        switch (SortBy)
        {
            case PlayingCardSort.SuitThenValue:
                value = CompareSuit(x, y);

                if (value == 0)
                    value = CompareValue(x, y);

                break;
            case PlayingCardSort.ValueThenSuit:
                value = CompareValue(x, y);

                if (value == 0)
                    value = CompareSuit(x, y);

                break;
            case PlayingCardSort.ValueOnly:
                value = CompareValue(x, y);

                break;
            case PlayingCardSort.SuitOnly:
                value = CompareSuit(x, y);

                break;
        }

        return value;
    }

    private static int CompareSuit(PlayingCard x, PlayingCard y)
    {
        if (x.Suit > y.Suit)
            return 1;

        if (x.Suit < y.Suit)
            return -1;

        return 0;
    }

    private int CompareValue(PlayingCard x, PlayingCard y)
    {

        int xVal = (int)x.Rank;
        int yVal = (int)y.Rank;

        // adjust values for an Ace if high
        if (AceIsHigh)
        {
            if (xVal == 1)
                xVal = 14;

            if (yVal == 1)
                yVal = 14;
        }

        // compare values
        if (xVal > yVal)
            return 1;

        if (xVal < yVal)
            return -1;

        return 0;
    }

    public PlayingCardSort SortBy { get; set; }
    public bool AceIsHigh { get; set; }
}
