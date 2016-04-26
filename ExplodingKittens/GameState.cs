
namespace ExplodingKittens
{
	public abstract class GameState
	{
		public Game Game { get; private set; }

		public GameState(Game game)
		{
			Game = game;
		}
	}
}
