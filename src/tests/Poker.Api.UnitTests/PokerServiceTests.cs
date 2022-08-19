using Poker.Api.Services;
using Poker.Api.Models;

namespace Poker.Api.UnitTests
{
    public class PokerServiceTests
    {
        private readonly PokerService _sut;

        public PokerServiceTests()
        {
            _sut = new PokerService();
        }

        [Fact]
        public async void StraightFlushTest()
        {
            // Arange
            var game = CreateGame(CreateStraightFlush());

            // Act
            var actual = await _sut.CalculateWinnerAsync(game);

            // Assert
            Assert.Equal(actual.Winner.HandRank, HandRank.StraightFlush);
        }

        [Fact]
        public async void FourOfKindTest()
        {
            // Arange
            var game = CreateGame(CreateFourOfKind());

            // Act
            var actual = await _sut.CalculateWinnerAsync(game);

            // Assert
            Assert.Equal(actual.Winner.HandRank, HandRank.FourOfKind);
            Assert.Equal(actual.Winner.CardRank, CardRank.Two);
        }

        [Fact]
        public async void FullHouseTest()
        {
            // Arange
            var game = CreateGame(CreateFullHouse());

            // Act
            var actual = await _sut.CalculateWinnerAsync(game);

            // Assert
            Assert.Equal(actual.Winner.HandRank, HandRank.FullHouse);
            Assert.Equal(actual.Winner.CardRank, CardRank.Seven);
        }

        private Hand CreateFullHouse()
        {
            return new Hand("Bill", new List<Card>
            {
                new Card("2H"),
                new Card("2S"),
                new Card("7H"),
                new Card("7C"),
                new Card("7D")
            });
        }
        private Hand CreateStraightFlush()
        {
            return new Hand("Bill", new List<Card>
            {
                new Card("2H"),
                new Card("3H"),
                new Card("4H"),
                new Card("5H"),
                new Card("6H")
            });
        }
        private Hand CreateFourOfKind()
        {
            return new Hand("Bill", new List<Card>
            {
                new Card("2H"),
                new Card("2D"),
                new Card("2D"),
                new Card("2C"),
                new Card("6H")
            });
        }

        private Game CreateGame(Hand one = null, Hand two = null)
        {
            if (one == null)
            {
                one = new Hand("Bill", new List<Card>
                {
                    new Card("2H"),
                    new Card("3H"),
                    new Card("10S"),
                    new Card("JD"),
                    new Card("AS")
                });
            }
            if (two == null)
            {
                two = new Hand("Ted", new List<Card>
                {
                    new Card("4H"),
                    new Card("JH"),
                    new Card("8D"),
                    new Card("KC"),
                    new Card("2D")
                });
            }
            return new Game(one, two);
        }
    }
}