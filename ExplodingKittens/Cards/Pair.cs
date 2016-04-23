
namespace ExplodingKittens.Cards
{
    public class Pair : Card
    {
        public Pair(string name)
            : base(name)
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
