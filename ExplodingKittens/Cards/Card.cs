using System;

namespace ExplodingKittens.Cards
{
    public abstract class Card
    {
        public string Name { get; set; }
        public string TagLine { get; set; }
        public string Explanation { get; set; }

        public Card(string name)
        {
            Name = name;
        }

        public Card(string name, string explanation)
        {
            Name = name;
            Explanation = explanation;
        }

        public Card(string name, string tagLine, string explanation)
        {
            Name = name;
            TagLine = tagLine;
            Explanation = explanation;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} {{{2}}}", Name, TagLine, Explanation);
        }
    }
}
