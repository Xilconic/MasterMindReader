using BoardGameEngine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.AreEqual(5, board.Size);
        }

        [Test]
        public void Size_SetAndGet_ReturnNewlySetValue()
        {
            // Setup
            var newValue = 18;

            var board = new GameBoard();

            // Call
            board.Size = newValue;

            // Assert
            Assert.AreEqual(newValue, board.Size);
        }

        [Test]
        [SetCulture("en-US")]
        public void Size_SetValueToLessThen0_ThrowArgumentOutOfRangeException()
        {
            // Setup
            var newValue = -1;

            var board = new GameBoard();

            // Call
            TestDelegate call = () => board.Size = newValue;

            // Assert
            var message = Assert.Throws<ArgumentOutOfRangeException>(call).Message;
            var expectedMessage = "Size cannot be negative." + Environment.NewLine +
                                  "Parameter name: value";
            Assert.AreEqual(expectedMessage, message);
        }
    }
}
