namespace BoardGameEngine
{
    /// <summary>
    /// This class represents 1 element that is part of <see cref="GameBoard"/>.
    /// </summary>
    public class GameBoardElement
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GameBoardElement"/> for a given coordinate in a
        /// <see cref="GameBoard"/>.
        /// </summary>
        /// <param name="primaryValue">The primary value.</param>
        /// <param name="secondaryValue">The secondary value.</param>
        public GameBoardElement(int primaryValue, int secondaryValue)
        {
            ElementValue = primaryValue;
            SecondaryElementValue = secondaryValue;
        }

        /// <summary>
        /// The primary element value.
        /// </summary>
        public double ElementValue { get; private set; }

        /// <summary>
        /// The secondary element value.
        /// </summary>
        public double SecondaryElementValue { get; private set; }
    }
}
