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
            Assert.AreEqual(ElementState.Empty, element.State);
        }

        [Test]
        [TestCase(ElementState.Empty)]
        [TestCase(ElementState.Yes)]
        [TestCase(ElementState.NotValue)]
        [TestCase(ElementState.NotColumn)]
        [TestCase(ElementState.NotRow)]
        [TestCase(ElementState.NeitherRowNorColumn)]
        public void MarkElement_SettingFirstValue_StateReturnThatValue(ElementState startingState)
        {
            // Setup
            var element = new GameBoardElement(0, 0);

            // Call
            element.MarkElement(startingState);

            // Assert
            Assert.AreEqual(startingState, element.State);
        }

        [Test]
        [TestCase(ElementState.Empty)]
        [TestCase(ElementState.Yes)]
        [TestCase(ElementState.NotValue)]
        [TestCase(ElementState.NotColumn)]
        [TestCase(ElementState.NotRow)]
        [TestCase(ElementState.NeitherRowNorColumn)]
        public void MarkElement_FromAnyStateToEmpty_StateReturnsEmpty(ElementState startingState)
        {
            // Setup
            var element = new GameBoardElement(0, 0);
            element.MarkElement(startingState);

            // Call
            element.MarkElement(ElementState.Empty);

            // Assert
            Assert.AreEqual(ElementState.Empty, element.State);
        }

        [Test]
        [TestCase(ElementState.NotValue)]
        [TestCase(ElementState.NotColumn)]
        [TestCase(ElementState.NotRow)]
        [TestCase(ElementState.NeitherRowNorColumn)]
        public void MarkElement_FromYesToAnyNotStates_StateReturnsNewNotState(ElementState newNotState)
        {
            // Setup
            var element = new GameBoardElement(0, 0);
            element.MarkElement(ElementState.Yes);

            // Call
            element.MarkElement(newNotState);

            // Assert
            Assert.AreEqual(newNotState, element.State);
        }

        [Test]
        [TestCase(ElementState.NotColumn)]
        [TestCase(ElementState.NotRow)]
        [TestCase(ElementState.NeitherRowNorColumn)]
        public void MarkElement_FromNotValueToAnyOtherNotStates_StateReturnsNewNotState(ElementState newNotState)
        {
            // Setup
            var element = new GameBoardElement(0, 0);
            element.MarkElement(ElementState.NotValue);

            // Call
            element.MarkElement(newNotState);

            // Assert
            Assert.AreEqual(newNotState, element.State);
        }

        [Test]
        [TestCase(ElementState.NotValue)]
        [TestCase(ElementState.NotColumn)]
        [TestCase(ElementState.NotRow)]
        [TestCase(ElementState.NeitherRowNorColumn)]
        public void MarkElement_FromAnyNotToYes_ThrowInvalidOperationException(ElementState notState)
        {
            // Setup
            var element = new GameBoardElement(0, 0);
            element.MarkElement(notState);

            // Call
            TestDelegate call = () => element.MarkElement(ElementState.Yes);

            // Assert
            string message = Assert.Throws<InvalidOperationException>(call).Message;
            Assert.AreEqual("Bug in game logic detected: Row marked as not matching cannot ever be marked as possible match later!", message);
        }

        [Test]
        public void MarkElement_FromNotRowToNotValue_StateRemainsNotRow()
        {
            // Setup
            var element = new GameBoardElement(0, 0);
            element.MarkElement(ElementState.NotRow);

            // Call
            element.MarkElement(ElementState.NotValue);

            // Assert
            Assert.AreEqual(ElementState.NotRow, element.State);
        }

        [Test]
        [TestCase(ElementState.NotColumn)]
        [TestCase(ElementState.NeitherRowNorColumn)]
        public void MarkElement_FromNotRowToSomeOtherNotStates_StateReturnsNeitherRowNorColumn(ElementState newNotState)
        {
            // Setup
            var element = new GameBoardElement(0, 0);
            element.MarkElement(ElementState.NotRow);

            // Call
            element.MarkElement(newNotState);

            // Assert
            Assert.AreEqual(ElementState.NeitherRowNorColumn, element.State);
        }

        [Test]
        public void MarkElement_FromNotColumnToNotValue_StateRemainsNotColumn()
        {
            // Setup
            var element = new GameBoardElement(0, 0);
            element.MarkElement(ElementState.NotColumn);

            // Call
            element.MarkElement(ElementState.NotValue);

            // Assert
            Assert.AreEqual(ElementState.NotColumn, element.State);
        }

        [Test]
        [TestCase(ElementState.NotRow)]
        [TestCase(ElementState.NeitherRowNorColumn)]
        public void MarkElement_FromNotColumnToSomeOtherNotStates_StateReturnsNeitherRowNorColumn(ElementState newNotState)
        {
            // Setup
            var element = new GameBoardElement(0, 0);
            element.MarkElement(ElementState.NotColumn);

            // Call
            element.MarkElement(newNotState);

            // Assert
            Assert.AreEqual(ElementState.NeitherRowNorColumn, element.State);
        }

        [Test]
        [TestCase(ElementState.NotValue)]
        [TestCase(ElementState.NotColumn)]
        [TestCase(ElementState.NotRow)]
        public void MarkElement_FromNeitherRowNorColumnToAnyOtherNotStates_StateKeepsReturningNeitherRowNorColumn(ElementState newNotState)
        {
            // Setup
            var element = new GameBoardElement(0, 0);
            element.MarkElement(ElementState.NeitherRowNorColumn);

            // Call
            element.MarkElement(newNotState);

            // Assert
            Assert.AreEqual(ElementState.NeitherRowNorColumn, element.State);
        }
    }
}
