using BoardGameEngine;
using NUnit.Framework;
using System;

namespace BoardGameEngineTest
{
    [TestFixture]
    public class GameBoardElementTest
    {
        [Test]
        public void ParameteredConstructor_ExpectedValues(
            [Random(0, int.MaxValue, 3)]int horizontalIndex,
            [Random(0, int.MaxValue, 3)]int verticalIndex)
        {
            // Call
            var element = new GameBoardElement(horizontalIndex, verticalIndex);

            // Assert
            Assert.AreEqual(horizontalIndex, element.ElementValue);
            Assert.AreEqual(verticalIndex, element.SecondaryElementValue);
        }
    }
}
