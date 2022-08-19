using System.Text.Json.Serialization;

namespace Poker.Api.Models
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public enum CardRank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }


    /// <summary>
    /// Card represented from a deck of 52 cards
    /// </summary>
    public class Card : IComparable
    {
        public Card(string id)
        {
            Id = id;
            Suit = GetSuitFromId(id);
            Rank = GetRankFromId(id);
        }

        public string Id { get; }

        [JsonIgnore]
        public Suit Suit { get; }
        
        [JsonIgnore]
        public CardRank Rank { get; }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            var other = obj as Card;
            if (other == null)
            {
                throw new ArgumentException("Object is not a Card");
            }

            return this.Rank.CompareTo(other.Rank);
        }

        private Suit GetSuitFromId(string id)
        {
            var s = id.Substring(1, 1).ToLower();
            switch(s)
            {
                case "d":
                    return Suit.Diamonds;
                case "h":
                    return Suit.Hearts;
                case "c":
                    return Suit.Clubs;
                case "s":
                    return Suit.Spades;
                    // todo error handling for defualt
                default:
                    return Suit.Spades;
            }
        }

        private CardRank GetRankFromId(string id)
        {
            var l = id.Length;
            var r = id.Remove(l-1, 1);
            switch(r)
            {
                case "2":
                    return CardRank.Two;
                case "3":
                    return CardRank.Three;
                case "4":
                    return CardRank.Four;
                case "5":
                    return CardRank.Five;
                case "6":
                    return CardRank.Six;
                case "7":
                    return CardRank.Seven;
                case "8":
                    return CardRank.Eight;
                case "9":
                    return CardRank.Nine;
                case "10":
                    return CardRank.Ten;
                case "J":
                    return CardRank.Jack;
                case "Q":
                    return CardRank.Queen;
                case "K":
                    return CardRank.King;
                case "A":
                    return CardRank.Ace;
                default:
                    return CardRank.Two;
            }
        }
    }
}