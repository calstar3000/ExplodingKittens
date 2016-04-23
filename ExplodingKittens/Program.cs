using System;

namespace ExplodingKittens
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Exploding Kittens.");
            new GameLoop().Start();
            Console.ReadKey();
        }
    }
}
