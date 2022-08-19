using Microsoft.AspNetCore.Mvc;
using Poker.Api.Models;
using Poker.Api.Services;

namespace Poker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokerController : ControllerBase
    {
        private readonly IPokerService _pokerService;

        public PokerController(IPokerService pokerService)
        {
            _pokerService = pokerService;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            Console.WriteLine($"Owner 1: {game.HandOne.Owner}, Owner 2: {game.HandTwo.Owner}");
            
            var result = await _pokerService.CalculateWinnerAsync(game);
            return CreatedAtAction(nameof(PostGame), new { id = result.Winner.Hand.Owner }, result);
        }


    }
}