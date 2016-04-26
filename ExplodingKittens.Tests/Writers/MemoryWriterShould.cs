﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExplodingKittens.Tests.Writers
{
	[TestClass]
	public class MemoryWriterShould
	{
		[TestMethod]
		public void StoreMessageWhenWritten()
		{
			// Arrange
			ExplodingKittens.Writers.MemoryWriter writer = new ExplodingKittens.Writers.MemoryWriter();

			// Act
			writer.Write("test");

			// Assert
			NUnit.Framework.Assert.AreEqual(writer.Message, "test");
		}
	}
}