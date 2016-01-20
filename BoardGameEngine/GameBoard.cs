using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameEngine
{
    /// <summary>
    /// This class represents the main square gameboard that the player will be using to deduce what 
    /// choice the other player has made.
    /// </summary>
    public class GameBoard
    {
        private int size;

        /// <summary>
        /// Instantiates a new instance of <see cref="GameBoard"/> with as <see cref="Size"/> of 5.
        /// </summary>
        public GameBoard()
        {
            size = 5;
        }

        /// <summary>
        /// The size of the game board, both in width and height.
        /// </summary>
        public int Size
        {
            get { return size; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Size cannot be negative.");
                }
                size = value;
            }
        }
    }
}
