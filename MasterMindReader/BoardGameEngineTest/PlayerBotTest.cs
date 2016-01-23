using BoardGameEngine;
using NUnit.Framework;
using System;

namespace BoardGameEngineTest
{
    [TestFixture]
    public class PlayerBotTest
    {
        [Test]
        public void AskLocation_BeforeChosenBoardElement_ThrowInvalidOperationException()
        {
            // Setup
            var board = new GameBoard();

            var bot = new PlayerBot(board);

            // Call
            TestDelegate call = () => bot.AskLocation(0, 0);

            // Assert
            var message = Assert.Throws<InvalidOperationException>(call).Message;
            Assert.AreEqual("But must have chosen a location first (call 'PlayerBot.ChooseBoardElement()') before calling this method.", message);
        }

        [Test]
        [TestCase(-20, 0)]
        [TestCase(-1, 0)]
        [TestCase(10, 0)]
        [TestCase(20, 0)]
        [TestCase(0, -30)]
        [TestCase(0, -1)]
        [TestCase(0, 10)]
        [TestCase(0, 30)]
        public void AskLocation_InvalidIndexes_ThrowArgumentOutOfRangeException(
            int horizontal, int vertical)
        {
            // Setup
            var board = new GameBoard();

            var bot = new PlayerBot(board);
            bot.ChooseBoardElement(new Random());

            // Call
            TestDelegate call = () => bot.AskLocation(horizontal, vertical);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(call);
        }

        [Test]
        public void AskLocation_NoMatches_ReturnFalse()
        {
            // Setup
            var board = new GameBoard();

            var bot = new PlayerBot(board);
            bot.ChooseBoardElement(new Random(1));

            // Call
            var answer = bot.AskLocation(0, 0);

            // Assert
            Assert.IsFalse(answer);
        }

        [Test]
        public void AskLocation_AtLocation_ReturnTrue()
        {
            // Setup
            var seed = 2;
            var inputRandom = new Random(seed);
            var referenceRandom = new Random(seed);
            var board = new GameBoard();

            var bot = new PlayerBot(board);
            bot.ChooseBoardElement(inputRandom);

            // Call
            var locationIndex = referenceRandom.Next(0, board.Size);
            var location2Index = referenceRandom.Next(0, board.Size);
            var answer = bot.AskLocation(locationIndex, location2Index);

            // Assert
            Assert.IsTrue(answer);
        }

        [Test]
        public void AskLocation_InSameColumn_ReturnTrue()
        {
            // Setup
            var seed = 2;
            var inputRandom = new Random(seed);
            var referenceRandom = new Random(seed);
            var board = new GameBoard();

            var bot = new PlayerBot(board);
            bot.ChooseBoardElement(inputRandom);

            // Call
            var locationIndex = referenceRandom.Next(0, board.Size);
            var location2Index = referenceRandom.Next(0, board.Size);
            var answer = bot.AskLocation(locationIndex+1, location2Index);

            // Assert
            Assert.IsTrue(answer);
        }

        [Test]
        public void AskLocation_InSameRow_ReturnTrue()
        {
            // Setup
            var seed = 2;
            var inputRandom = new Random(seed);
            var referenceRandom = new Random(seed);
            var board = new GameBoard();

            var bot = new PlayerBot(board);
            bot.ChooseBoardElement(inputRandom);

            // Call
            var locationIndex = referenceRandom.Next(0, board.Size);
            var location2Index = referenceRandom.Next(0, board.Size);
            var answer = bot.AskLocation(locationIndex, location2Index+1);

            // Assert
            Assert.IsTrue(answer);
        }

        [Test]
        public void AskLocation_ElementWithSameElementValue_ReturnTrue()
        {
            // Setup
            var seed = 2;
            var inputRandom = new Random(seed);
            var referenceRandom = new Random(seed);
            var board = new GameBoard();

            var locationIndex = referenceRandom.Next(0, board.Size);
            var location2Index = referenceRandom.Next(0, board.Size);
            var expectedChosenElement = board.Elements[locationIndex, location2Index];

            int inputRowIndex = -1, intputColumnIndex = -1;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (expectedChosenElement.ElementValue == board.Elements[i, j].ElementValue)
                    {
                        inputRowIndex = i;
                        intputColumnIndex = j;
                    }
                }
            }

            var bot = new PlayerBot(board);
            bot.ChooseBoardElement(inputRandom);

            // Call

            var answer = bot.AskLocation(inputRowIndex, intputColumnIndex);

            // Assert
            Assert.IsTrue(answer);
        }

        [Test]
        public void AskLocation_ElementWithSameSecondaryElementValue_ReturnTrue()
        {
            // Setup
            var seed = 2;
            var inputRandom = new Random(seed);
            var referenceRandom = new Random(seed);
            var board = new GameBoard();

            var locationIndex = referenceRandom.Next(0, board.Size);
            var location2Index = referenceRandom.Next(0, board.Size);
            var expectedChosenElement = board.Elements[locationIndex, location2Index];

            int inputRowIndex = -1, intputColumnIndex = -1;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (expectedChosenElement.SecondaryElementValue == board.Elements[i, j].SecondaryElementValue)
                    {
                        inputRowIndex = i;
                        intputColumnIndex = j;
                    }
                }
            }

            var bot = new PlayerBot(board);
            bot.ChooseBoardElement(inputRandom);

            // Call

            var answer = bot.AskLocation(inputRowIndex, intputColumnIndex);

            // Assert
            Assert.IsTrue(answer);
        }
    }
}
