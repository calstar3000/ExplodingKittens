
namespace ExplodingKittens.Cards
{
    public class ExplodingKitten : Card
    {
        public ExplodingKitten()
            : base("Exploding Kitten", "Show this card immediately.")
        {

        }

        public override string ToString()
        {
            return string.Format("{0} {{{1}}}", Name, Explanation);
        }
    }
}
