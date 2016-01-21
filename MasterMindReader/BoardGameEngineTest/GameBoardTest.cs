using BoardGameEngine;
using NUnit.Framework;
using System;

namespace BoardGameEngineTest
{
    [TestFixture]
    public class GameBoardTest
    {
        [Test]
        public void DefaultConstructor_ExpectedValues()
        {
            // Call
            var board = new GameBoard();

            // Assert
            Assert.AreEqual(10, board.Size);
        }
    }
}
