namespace PlayingCards;

public enum PlayingCardRank
{
    Ace = 14,
    King = 13,
    Queen = 12,
    Jack = 11,
    Ten = 10,
    Nine = 9,
    Eight = 8,
    Seven = 7,
    Six = 6,
    Five = 5,
    Four = 4,
    Three = 3,
    Two = 2,
}

public static class PlayingCardRankExtensions
{
    public static string CardChar(this PlayingCardRank rank)
    {
        int rk = (int)rank;
        string rtn = rk.ToString();

        switch (rk)
        {
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                // do nothing - return default rank int (2 - 10)
                break;
            default:
                // return the first letter of the rank (A, K, Q, J)
                rtn = rank.ToString().First().ToString();
                break;
        }

        return rtn;
    }
}
