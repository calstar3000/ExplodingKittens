using ExplodingKittens.Cards;
using System;
using System.Collections.Generic;

namespace ExplodingKittens
{
    public class Hand
    {
        public List<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new List<Card>();
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
