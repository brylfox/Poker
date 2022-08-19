namespace Poker.Api.Models
{
    public class Game
    {
        public Game(Hand handOne, Hand handTwo)
        {
            HandOne = handOne;
            HandTwo = handTwo;
        }

        public Hand HandOne { get; }
        public Hand HandTwo { get; }
    }
}