using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ExplodingKittens.Tests.Cards
{
    [TestClass]
    public class ShuffleShould
    {
        [TestMethod]
        public void Have_non_empty_explanation()
        {
            // Arrange & Act
            ExplodingKittens.Cards.Shuffle shuffle = new ExplodingKittens.Cards.Shuffle("Test shuffle card");

            // Assert
            NUnit.Framework.Assert.IsNotEmpty(shuffle.Explanation);
        }
    }
}
