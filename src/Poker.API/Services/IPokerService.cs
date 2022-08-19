using Poker.Api.Models;

namespace Poker.Api.Services
{
    public interface IPokerService
    {
        /// <summary>
        /// Calculate the Best hand.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        Task<GameResult> CalculateWinnerAsync(Game game);
    }
}