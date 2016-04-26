﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ExplodingKittens.Tests
{
	[TestClass]
	public class GameLoopShould
	{
		[TestMethod]
		public void Create_a_null_game_when_it_is_created()
		{
			// Arrange, act
			GameLoop loop = new GameLoop();

			// Assert
			NUnit.Framework.Assert.IsNull(loop.Game);
		}
	}
}
