using ExplodingKittens.Cards;
using System;
using System.Collections.Generic;

namespace ExplodingKittens
{
    public class Game
    {
        public Player[] Players { get; set; }
        public Deck Deck { get; set; }

        public Game(int numberOfPlayers)
        {
            if (numberOfPlayers < 2)
                throw new ArgumentException("The number of players must be at least two.");
            if (numberOfPlayers > 5)
                throw new ArgumentException("The number of players must be at most five.");

            Setup(numberOfPlayers);
            ListHands();
            ListDrawPile();
        }

        private void Setup(int numberOfPlayers)
        {
            AddPlayers(numberOfPlayers);
            Deck = new Deck(numberOfPlayers);
            Deal();
        }

        private void AddPlayers(int numberOfPlayers)
        {
            Players = new Player[numberOfPlayers];

            for (int playerIndex = 0; playerIndex < numberOfPlayers; playerIndex++)
            {
                Players[playerIndex] = new Player(playerIndex + 1);
            }

            SetActivePlayer();
        }

        /// <summary>
        /// TODO: Randomise choosing of the starting player
        /// </summary>
        private void SetActivePlayer()
        {
            Players[0].IsActive = true;
        }
       
        public void Deal()
        {
            Console.WriteLine("Dealing cards...\n");
            Deck.Shuffle();
            DealInitialCards();
            DealDefuseCards();
            Deck.AddExplodingKittenCards();
            Deck.Shuffle();
        }

        private void ListHands()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(string.Format("Player {0}'s hand:", player.Number));
                player.Hand.ToString();
                Console.WriteLine();
            }
        }

        private void ListDrawPile()
        {
            Console.WriteLine("Draw pile:");
            Deck.ToString();
            Console.WriteLine();
        }

        /// <summary>
        /// Deal a defuse card to each play and add the remaining cards to the deck and shuffle
        /// </summary>
        private void DealDefuseCards()
        {
            Stack<Card> defuseCards = Deck.GetDefuseCards();

            foreach (Player player in Players)
            {
                player.Hand.Cards.Add(defuseCards.Pop());
            }

            foreach (Card defuseCard in defuseCards)
            {
                Deck.Cards.Push(defuseCard);
            }
        }

        private void DealInitialCards()
        {
            int initialCards = 4;
            foreach (Player player in Players)
            {
                for (int dealIndex = 0; dealIndex < initialCards; dealIndex++)
                {
                    player.Hand.Cards.Add(Deck.Cards.Pop());
                }
            }
        }
    }
}
