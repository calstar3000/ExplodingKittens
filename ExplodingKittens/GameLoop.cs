using ExplodingKittens.Writers;
using System;

namespace ExplodingKittens
{
	public class GameLoop
	{
		public Game Game { get; set; }
		public Player CurrentPlayer { get; set; }
		public ActionResponse CurrentActionResponse { get; set; }
		public int CurrentTargetPlayerIndex { get; set; }
		public int CurrentCardIndex { get; set; }
		public string CurrentCommand { get; set; }

		public GameLoop()
		{
		}

		public void Setup()
		{
			while (Game == null)
			{
				Console.WriteLine("Welcome to Exploding Kittens. Please enter the number of players (between 2 and 5): ");

				//string input = Console.ReadLine();
				//int numberOfPlayers = string.IsNullOrEmpty(input) ? 0 : Convert.ToInt32(input);
				int numberOfPlayers = 2;
				Console.WriteLine();

				try
				{
					Game = new Game(numberOfPlayers, new ConsoleWriter());

					Start();
				}
				catch (ArgumentException e)
				{
					Console.WriteLine(string.Format("{0}\n", e.Message));
				}
			}
		}

		public bool IsPlayerBeingAskedForFavor
		{
			get { return !(Game.PlayerBeingAskedForFavor is NullPlayer); }
		}

		private void Start()
		{
			while (!Game.HasFinished)
			{
				CurrentPlayer = Game.ActivePlayer;

				while (!TurnHasFinished())
				{
					CurrentActionResponse = new ActionResponse(Game.Writer);
					CheckIfFavorHasBeenPlayed();
					CurrentCommand = Console.ReadLine();
					Game.Writer.WriteLine();
					ToggleSelectCard();
					PlayGiveStealCard();
					CurrentActionResponse = Game.GetCommand(CurrentCommand, CurrentPlayer, CurrentCardIndex, CurrentTargetPlayerIndex).Execute();
					CurrentActionResponse.PrintErrors();
					CurrentActionResponse.PrintMessages();
					
					// reset
					CurrentTargetPlayerIndex = 0;
				}
			}

			Game.EndGame();
		}

		/// <summary>
		/// Turn has finished when the active player has changed, and the current player 
		/// isn't being asked for a favour or stolen from
		/// </summary>
		/// <returns>Whether the current player's turn has finished or not</returns>
		private bool TurnHasFinished()
		{
			return (Game.HasFinished ||
				(CurrentPlayer.Id != Game.ActivePlayer.Id && 
				!CurrentPlayer.IsAskedForFavor && 
				!CurrentPlayer.IsBeingStolenFrom));
		}

		/// <summary>
		/// Check to see if a favour card has been played
		/// </summary>
		private void CheckIfFavorHasBeenPlayed()
		{
			if (IsPlayerBeingAskedForFavor)
			{
				CurrentPlayer = Game.PlayerBeingAskedForFavor;
				Game.PrintFavorMessage(CurrentPlayer.Id);
			}
			else
			{
				Game.PrintTurnMessage(CurrentPlayer.Id);
			}
		}

		/// <summary>
		/// Parse a give or steal card command
		/// </summary>
		private void PlayGiveStealCard()
		{
			if ((CurrentCommand.StartsWith("play ") || CurrentCommand.StartsWith("give ") || CurrentCommand.StartsWith("steal ")) &&
				(CurrentCommand != "play" && CurrentCommand != "give" && CurrentCommand != "steal"))
			{
				CurrentTargetPlayerIndex = Convert.ToInt32(CurrentCommand.Split(' ')[1]);

				if (CurrentCommand.StartsWith("play ")) CurrentCommand = "play";
				if (CurrentCommand.StartsWith("give ")) CurrentCommand = "give";
				if (CurrentCommand.StartsWith("steal ")) CurrentCommand = "steal";
			}
		}

		/// <summary>
		/// Parse a select or deselect card command
		/// </summary>
		private void ToggleSelectCard()
		{
			if ((CurrentCommand.StartsWith("select ") || CurrentCommand.StartsWith("deselect ")) &&
				(CurrentCommand != "select" && CurrentCommand != "deselect"))
			{
				CurrentCardIndex = Convert.ToInt32(CurrentCommand.Split(' ')[1]);

				if (CurrentCommand.StartsWith("select ")) CurrentCommand = "select";
				if (CurrentCommand.StartsWith("deselect ")) CurrentCommand = "deselect";
			}
		}
	}
}
