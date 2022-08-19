namespace Poker.Api.Models
{
    public class GameResult
    {
        public GameResult(HandResult winner, HandResult loser)
        {
            Winner = winner;
            Loser = loser;
        }

        public HandResult Winner { get; }

        public HandResult Loser { get;  }
    }
}