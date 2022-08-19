namespace Poker.Api.Models
{
    public class Hand
    {
        public Hand(string owner, List<Card> cards)
        {
            Owner = owner;
            Cards = cards;
        }

        public string Owner { get; }
        public List<Card> Cards { get; }
    }
}