using System;

namespace BoardGameEngine
{
    /// <summary>
    /// This class defines a bot opponent to play the game against.
    /// </summary>
    public class PlayerBot
    {
        private GameBoard board;
        private int chosenHorizontalIndex, chosenVeritcalIndex;

        /// <summary>
        /// Instantiates a new instance of <see cref="PlayerBot"/> to play with a specified board.
        /// </summary>
        /// <param name="board">The game board to play with.</param>
        public PlayerBot(GameBoard board)
        {
            this.board = board;

            chosenHorizontalIndex = -1;
            chosenVeritcalIndex = -1;
        }

        /// <summary>
        /// Make the bot chose a location on the board that another player must deduce.
        /// </summary>
        /// <param name="random">The random number generator to be used.</param>
        public void ChooseBoardElement(Random random)
        {
            chosenHorizontalIndex = random.Next(0, board.Size);
            chosenVeritcalIndex = random.Next(0, board.Size);
        }

        /// <summary>
        /// Ask the bot if the given board location has any feature in common with its chosen location.
        /// </summary>
        /// <param name="horizontalIndex">The row-index of the board location.</param>
        /// <param name="verticalIndex">The column-index of the board location.</param>
        /// <returns>True if any or all features match its chosen location; false if none of the features
        /// match its chosen location.</returns>
        public bool AskLocation(int horizontalIndex, int verticalIndex)
        {
            if (chosenHorizontalIndex == -1)
            {
                throw new InvalidOperationException("But must have chosen a location first (call 'PlayerBot.ChooseBoardElement()') before calling this method.");
            }
            if (horizontalIndex < 0 || horizontalIndex >= board.Size)
            {
                var message = string.Format("Argument must be in range [0, {0}], but was {1}.",
                                            board.Size - 1, horizontalIndex);
                throw new ArgumentOutOfRangeException("horizontalIndex", message);
            }
            if (verticalIndex < 0 || verticalIndex >= board.Size)
            {
                var message = string.Format("Argument must be in range [0, {0}], but was {1}.",
                            board.Size - 1, verticalIndex);
                throw new ArgumentOutOfRangeException("verticalIndex", message);
            }

            return chosenHorizontalIndex == horizontalIndex || chosenVeritcalIndex == verticalIndex ||
                board.Elements[chosenHorizontalIndex, chosenVeritcalIndex].ElementValue == board.Elements[horizontalIndex, verticalIndex].ElementValue ||
                board.Elements[chosenHorizontalIndex, chosenVeritcalIndex].SecondaryElementValue == board.Elements[horizontalIndex, verticalIndex].SecondaryElementValue;
        }
    }
}
