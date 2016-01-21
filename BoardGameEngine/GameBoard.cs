using System;
using System.IO;
using System.Linq;

namespace BoardGameEngine
{
    /// <summary>
    /// This class represents the main square game board that the player will be using to deduce what 
    /// choice the other player has made.
    /// </summary>
    public class GameBoard
    {
        private readonly int size;
        private GameBoardElement[,] elements;

        /// <summary>
        /// Instantiates a new instance of <see cref="GameBoard"/> with as <see cref="Size"/> of 10.
        /// </summary>
        public GameBoard()
        {
            // 10 x 10 with duplicity of 4 results 5 primary with 5 secondary element values
            size = 10;

            GenerateElements();
        }

        private void GenerateElements()
        {
            elements = new GameBoardElement[size, size];

            string name = GetType().Assembly.GetManifestResourceNames().First(n => n.EndsWith("BrainFreezeBoard.txt"));
            Stream boardInitStream = GetType().Assembly.GetManifestResourceStream(name);
            using(var reader = new StreamReader(boardInitStream))
            {
                for (int i = 0; i < size; i++)
                {
                    var textElements = reader.ReadLine().Split(new[] { ' ' });
                    for (int j = 0; j < size; j++)
                    {
                        var elementCode = textElements[j];
                        int primaryValue = Convert.ToInt32(elementCode[0]);
                        int secondaryValue = GetValueFromChar(elementCode[1]);
                        elements[i, j] = new GameBoardElement(primaryValue, secondaryValue);
                    }
                }
            }
        }

        private int GetValueFromChar(char character)
        {
            if (character == 'A')
            {
                return 1;
            }
            else if (character == 'B')
            {
                return 2;
            }
            else if (character == 'C')
            {
                return 3;
            }
            else if (character == 'D')
            {
                return 4;
            }
            else if (character == 'E')
            {
                return 5;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// The size of the game board, both in width and height.
        /// </summary>
        public int Size
        {
            get { return size; }
        }

        public GameBoardElement[,] Elements { get { return elements; } }
    }
}
