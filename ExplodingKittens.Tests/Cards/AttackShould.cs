using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ExplodingKittens.Tests.Cards
{
    [TestClass]
    public class AttackShould
    {
        [TestMethod]
        public void Have_non_empty_explanation()
        {
            // Arrange & Act
            ExplodingKittens.Cards.Attack attack = new ExplodingKittens.Cards.Attack("Test attack card");

            // Assert
            NUnit.Framework.Assert.IsNotEmpty(attack.Explanation);
        }
    }
}
