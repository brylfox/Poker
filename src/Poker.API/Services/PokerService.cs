using Poker.Api.Models;

namespace Poker.Api.Services
{
    public class PokerService : IPokerService
    {
        public PokerService()
        {
        }

        /// <inheritdoc/>
        public Task<GameResult> CalculateWinnerAsync(Game game)
        {
            return Task.Run(() => {
                var handOne = GetHandResult(game.HandOne);
                var handTwo = GetHandResult(game.HandTwo);
                var compare = handOne.CompareTo(handTwo);
                if (compare == 1)
                {
                    return new GameResult(handOne, handTwo);
                }
                else
                {
                    return new GameResult(handTwo, handOne);
                }
            });            
        }

        private HandResult GetHandResult(Hand hand)
        {
            var consecutive = CountConsecutive(hand);
            var cardRank = hand.Cards.Max(c => c.Rank);
            if (IsStraightFlush(hand, consecutive))
            {
                return new HandResult(hand, HandRank.StraightFlush, cardRank);
            }

            var fourOfKindRank = GetFourOfKindRank(hand);
            if (fourOfKindRank.HasValue)
            {
                return new HandResult(hand, HandRank.FourOfKind, fourOfKindRank.Value);
            }

            var fullHouseRank = GetFullHouseRank(hand);
            if (fullHouseRank.HasValue)
            {
                return new HandResult(hand, HandRank.FullHouse, fullHouseRank.Value);
            }

            if (IsFlush(hand))
            {
                return new HandResult(hand, HandRank.Flush, cardRank);
            }

            if (IsStraight(hand, consecutive))
            {
                return new HandResult(hand, HandRank.Straight, cardRank);
            }

            var threeOfKindRank = GetThreeOfKindRank(hand);
            if (threeOfKindRank.HasValue)
            {
                return new HandResult(hand, HandRank.ThreeOfKind, threeOfKindRank.Value);
            }

            var twoPairRank = GetTwoPairsRank(hand);
            if (twoPairRank.HasValue)
            {
                return new HandResult(hand, HandRank.TwoPairs, twoPairRank.Value);
            }


            return new HandResult(hand, HandRank.HighCard, cardRank);
        }

        /// <summary>
        /// Determine if a pair is present.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>Rank value of pair found otherwise null</returns>
        private CardRank? GetPairRank(Hand hand)
        {
            for (var index = 0; index < 4; ++index)
            {
                var rank = hand.Cards[index].Rank;
                if (hand.Cards.Count(c => c.Rank == rank) == 2)
                {
                    return rank;
                }
            }
            return null;
        }

        /// <summary>
        /// Determine if two different pairs are present.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>Rank of highest pair found otherwise null</returns>
        private CardRank? GetTwoPairsRank(Hand hand)
        {
            CardRank? pairOne = null;
            CardRank? pairTwo = null;
            for (var index = 0; index < 4; ++index)
            {
                var rank = hand.Cards[index].Rank;
                if (hand.Cards.Count(c => c.Rank == rank) == 2)
                {
                    if (!pairOne.HasValue)
                    {
                        pairOne = rank;
                    }
                    else if (pairOne != rank)
                    {
                        pairTwo = rank;
                    }
                }
            }

            return pairOne.HasValue && pairTwo.HasValue ?
                pairOne > pairTwo ? pairOne : pairTwo
                : null;
        }

        /// <summary>
        /// Determine if three cards have same rank.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>Rank value if three of a kind found otherwise null</returns>
        private CardRank? GetThreeOfKindRank(Hand hand)
        {
            for (var index = 0; index < 3; ++index)
            {
                var rank = hand.Cards[index].Rank;
                if (hand.Cards.Count(c => c.Rank == rank) == 3)
                {
                    return rank;
                }
            }
            return null;
        }

        /// <summary>
        /// Determine if a full house rank (3 of a kind and 2 of a kind)
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>Rank value of three pair if full house otherwise null</returns>
        private CardRank? GetFullHouseRank(Hand hand)
        {
            CardRank? pairRank = null;
            CardRank? threeRank = null;
            for (var index = 0; index < 3; ++index)
            {
                var rank = hand.Cards[index].Rank;
                var count = hand.Cards.Count(c => c.Rank == rank);
                if (count == 3)
                {
                    threeRank = rank;
                }
                else if (count == 2)
                {
                    pairRank = rank;
                }
                
            }
            return null;
        }

        /// <summary>
        /// Determine if four cards have the same value.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>Rank value of four cards.</returns>
        private CardRank? GetFourOfKindRank(Hand hand)
        {
            for (var index = 0; index < 2; ++index)
            {
                var rank = hand.Cards[index].Rank;
                if (hand.Cards.Count(c => c.Rank == rank) == 4)
                {
                    return rank;
                }
            }
            return null;
        }

        /// <summary>
        /// Check for a straight flush: 5 consecutive cards of same suit.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>true if hand is a straight flush otherwise false</returns>
        private bool IsStraightFlush(Hand hand, int consecutive) 
                => IsStraight(hand, consecutive) && IsFlush(hand);

        /// <summary>
        /// Check if all cards are same suit.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns>true if all same suit otherwise false</returns>
        private bool IsFlush(Hand hand) 
                => hand.Cards.Select(c => c.Suit).Distinct().Count() == 1;

        /// <summary>
        /// Card values are 5 consecutive ranks.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="consecutive"></param>
        /// <returns>true if 5 consecutive ranks otherwise false</returns>
        private bool IsStraight(Hand hand, int consecutive) 
                => consecutive == 5;

        private int CountConsecutive(Hand hand)
        {
            var rank = hand.Cards.Select(c => (int)c.Rank).OrderBy(i => i).ToList();
            var consecutive = 1;
            var high = 1;
            for (var index = 1; index < rank.Count(); ++index)
            {
                if (rank[index] - rank[index - 1] != 1)
                {
                    if (consecutive > high)
                    {
                        high = consecutive;
                    }
                    consecutive = 1;
                    continue;
                }
                ++consecutive;
            }
            
            return high > consecutive ? high : consecutive;
        }
    }
}