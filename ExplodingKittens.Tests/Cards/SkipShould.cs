using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ExplodingKittens.Tests.Cards
{
    [TestClass]
    public class SkipShould
    {
        [TestMethod]
        public void Have_non_empty_explanation()
        {
            // Arrange & Act
            ExplodingKittens.Cards.Skip skip = new ExplodingKittens.Cards.Skip("Test skip card");

            // Assert
            NUnit.Framework.Assert.IsNotEmpty(skip.Explanation);
        }
    }
}
