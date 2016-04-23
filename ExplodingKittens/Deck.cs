using ExplodingKittens.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplodingKittens
{
    public class Deck
    {
        public int NumberOfPlayers { get; set; }
        public Stack<Card> Cards { get; set; }

        public Deck(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            Cards = new Stack<Card>();
            AddAttackCards();
            AddFavorCards();
            AddShuffleCards();
            AddSeeTheFutureCards();
            AddNopeCards();
            AddSkipCards();
            AddPairCards();
        }

        public void Shuffle()
        {
            Card[] cardsArray = this.Cards.ToArray();
            List<Card> unshuffledCards = new List<Card>();

            foreach(Card card in cardsArray)
            {
                unshuffledCards.Add(card);
            }

            Stack<Card> shuffledCards = new Stack<Card>();
            while (unshuffledCards.Count > 0)
            {
                int randomCardIndex = new Random().Next(0, unshuffledCards.Count);
                shuffledCards.Push(unshuffledCards[randomCardIndex]);
                unshuffledCards.RemoveAt(randomCardIndex);
            }

            this.Cards = shuffledCards;
        }

        public void AddExplodingKittenCards()
        {
            for (int playerIndex = 0; playerIndex < NumberOfPlayers - 1; playerIndex++)
            {
                Cards.Push(new ExplodingKitten());
            }
        }

        public Stack<Card> GetDefuseCards()
        {
            Stack<Card> defuseCards = new Stack<Card>();
            defuseCards.Push(new Defuse("Via nature documentaries"));
            defuseCards.Push(new Defuse("Via porkback riding into the sunset together"));
            defuseCards.Push(new Defuse("Via spray / neuter"));
            defuseCards.Push(new Defuse("Via crate"));
            defuseCards.Push(new Defuse("Via mauling a baby"));
            defuseCards.Push(new Defuse("Via excessive ball-cleaning"));

            return defuseCards;
        }

        private void AddPairCards()
        {
            int maxPairCardOfType = 4;
            for (int pairCardIndex = 0; pairCardIndex < maxPairCardOfType; pairCardIndex++)
            {
                Cards.Push(new BikiniCat());
                Cards.Push(new MommaCat());
                Cards.Push(new ShyBladderCat());
                Cards.Push(new ShrodingerCat());
                Cards.Push(new ZombieCat());
            }
        }

        private void AddSkipCards()
        {
            Cards.Push(new Skip("Evade dirty sasquatch underpants"));
            Cards.Push(new Skip("Sail away on your penis balloon. Be free, little buddy."));
            Cards.Push(new Skip("Play a game of whale bonder tetherball"));
            Cards.Push(new Skip("Go base jumping using a pair of old lady boobs"));
        }

        private void AddNopeCards()
        {
            Cards.Push(new Nope("Awaken The Narnope"));
            Cards.Push(new Nope("Feed your opponent some cantanope"));
            Cards.Push(new Nope("Deliver some nope on your jump rope"));
            Cards.Push(new Nope("The Pope of Nope has spoken"));
            Cards.Push(new Nope("Put on your necktie of nope. Holy smokes you look good."));
        }

        private void AddSeeTheFutureCards()
        {
            Cards.Push(new SeeTheFuture("Attach a butterfly to your genitals and see where it takes you in life"));
            Cards.Push(new SeeTheFuture("Drink an entire bottle of bald eagle tears"));
            Cards.Push(new SeeTheFuture("Discover a boob wizard living in your boobs. Listen to the secrets he tells."));
            Cards.Push(new SeeTheFuture("Weave an infinity boner an live forever, fo it is the most sacren of boners."));
            Cards.Push(new SeeTheFuture("Crawl inside a goat butt and see many wondrous things"));
        }

        private void AddShuffleCards()
        {
            Cards.Push(new Shuffle("Discover you have a toilet werewolf"));
            Cards.Push(new Shuffle("An asparagus bum dragon appears"));
            Cards.Push(new Shuffle("A kraken emerges and he's super upset"));
            Cards.Push(new Shuffle("Smoke some crack with a baby owl"));
        }

        private void AddFavorCards()
        {
            Cards.Push(new Favor("\"Baby Robin\" your best friend"));
            Cards.Push(new Favor("Teach someone a new palindrome"));
            Cards.Push(new Favor("Fall so deeply in love you it gives you both crazy diarrhea"));
            Cards.Push(new Favor("Donate your body to cat science"));
        }

        private void AddAttackCards()
        {
            Cards.Push(new Attack("Whip out your rubber dick collection"));
            Cards.Push(new Attack("Grow a magnificent squid arm and start slapping fat babies"));
            Cards.Push(new Attack("Release the torture bunnies"));
            Cards.Push(new Attack("Unleash some adorable penguin diarrhea"));
        }

        public new void ToString()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
