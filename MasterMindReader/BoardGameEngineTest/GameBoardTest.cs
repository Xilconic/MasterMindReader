using BoardGameEngine;
using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void MarkYes_ElementStateChangesToYes()
        {
            // Setup
            var board = new GameBoard();

            var rowIndex = 0;
            var columnIndex = 0;

            // Call
            board.MarkYes(rowIndex, columnIndex);

            // Assert
            Assert.AreEqual(ElementState.Yes, board.Elements[rowIndex, columnIndex].State);
        }

        [Test]
        public void MarkNo_UpdateGameBoardState()
        {
            // Setup
            var board = new GameBoard();

            var rowIndex = 4;
            var columnIndex = 3;

            // Call
            board.MarkNo(rowIndex, columnIndex);

            // Assert
            Assert.AreEqual(ElementState.NeitherRowNorColumn, board.Elements[rowIndex, columnIndex].State);

            // All other elements in that row update to 'NotRow'
            foreach (int index in Enumerable.Range(0, board.Size).Except(new[] { columnIndex }))
            {
                Assert.AreEqual(ElementState.NotRow, board.Elements[rowIndex, index].State);
            }

            // All other elements in that column update to 'NotColumn'
            foreach (int index in Enumerable.Range(0, board.Size).Except(new[] { rowIndex }))
            {
                Assert.AreEqual(ElementState.NotColumn, board.Elements[index, columnIndex].State);
            }
        }
    }
}
