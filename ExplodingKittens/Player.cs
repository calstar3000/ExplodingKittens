
namespace ExplodingKittens
{
    public class Player
    {
        public int Number { get; set; }
        public Hand Hand { get; set; }
        public bool IsActive { get; set; }
        public bool IsWinner { get; set; }

        public Player(int number)
        {
            Number = number;
            Hand = new Hand();
        }
    }
}
