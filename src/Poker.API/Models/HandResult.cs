namespace Poker.Api.Models
{
    public enum HandRank
    {
        HighCard = 0,
        Pair = 1,
        TwoPairs = 2,
        ThreeOfKind = 3,
        Straight = 4,
        Flush = 5,
        FullHouse = 6,
        FourOfKind = 7,
        StraightFlush = 8
    }

    public class HandResult : IComparable
    {
        public HandResult(Hand hand, HandRank handRank, CardRank cardRank)
        {
            Hand = hand;
            HandRank = handRank;
            CardRank = cardRank;
        }

        public Hand Hand { get; }
        public HandRank HandRank { get; }

        public CardRank CardRank { get; }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            var other = obj as HandResult;
            if (other == null)
            {
                throw new ArgumentException("Object is not a Hand Result");
            }

            if (this.HandRank != other.HandRank)
            {
                return this.HandRank.CompareTo(other.HandRank);
            }

            return this.CardRank.CompareTo(other.CardRank);
        }
    }
}