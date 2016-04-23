using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ExplodingKittens.Tests
{
    [TestClass]
    public class GameShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void Have_at_least_two_players(int numberOfPlayers)
        {
            // Arrange & act
            Game game = new Game(numberOfPlayers);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(100)]
        public void Have_at_most_five_players(int numberOfPlayers)
        {
            // Arrange & act
            Game game = new Game(numberOfPlayers);
        }
    }
}
