using System;
using System.Linq;

namespace ExplodingKittens
{
    public class GameLoop
    {
        public bool HasFinished 
        { 
            get 
            {
                return Game.Players.Any(player => player.IsWinner);
            } 
        }
        public Game Game { get; set; }

        public GameLoop()
        {
            Game = null;
        }

        public void Start()
        {
            while (Game == null)
            {
                Console.WriteLine("Please enter the number of players (between 2 and 5): ");

                string input = Console.ReadLine();
                int numberOfPlayers = string.IsNullOrEmpty(input) ? 0 : Convert.ToInt32(input);
                Console.WriteLine();

                try
                {
                    Game = new Game(numberOfPlayers);

                    StartTurnLoop();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(string.Format("{0}\n", e.Message));
                }
            }
        }

        public void StartTurnLoop()
        {
            while (!HasFinished)
            {
                Game.Players[0].IsWinner = true;
            }

            Console.WriteLine(string.Format("Congratulations player {0}, you won the game!", Game.Players.Where(player => player.IsWinner).First().Number));
        }
    }
}
