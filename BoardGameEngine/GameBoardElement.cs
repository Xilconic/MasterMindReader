﻿using System;

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

        /// <summary>
        /// Denotes the game state of the board-element.
        /// </summary>
        public ElementState State { get; private set; }

        /// <summary>
        /// Update the <see cref="State"/> of this element given information changes to the state.
        /// </summary>
        /// <param name="markingState">The new information about the element.</param>
        public void MarkElement(ElementState markingState)
        {
            if (markingState == ElementState.Yes && 
                (State == ElementState.NotValue || State == ElementState.NotRow || 
                 State == ElementState.NotColumn || State == ElementState.NeitherRowNorColumn))
            {
                throw new InvalidOperationException("Bug in game logic detected: Row marked as not matching cannot ever be marked as possible match later!");
            }
            if (markingState == ElementState.NotValue && 
                (State == ElementState.NotRow || State == ElementState.NotColumn || 
                 State == ElementState.NeitherRowNorColumn))
            {
                return;
            }
            if ((markingState == ElementState.NotRow && State == ElementState.NotColumn) ||
                (markingState == ElementState.NotColumn && State == ElementState.NotRow))
            {
                State = ElementState.NeitherRowNorColumn;
                return;
            }
            if (State == ElementState.NeitherRowNorColumn && (markingState == ElementState.NotRow || markingState == ElementState.NotColumn))
            {
                return;
            }
            State = markingState;
        }
    }
}
