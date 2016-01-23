namespace BoardGameEngine
{
    /// <summary>
    /// Marks the game state of an instance of <see cref="GameBoardElement"/>.
    /// </summary>
    public enum ElementState
    {
        /// <summary>
        /// No information is available about the element.
        /// </summary>
        Empty,
        /// <summary>
        /// The element matches any or all of the following:
        /// <list type="bullet">
        /// <item>The row of the element.</item>
        /// <item>The column of the element.</item>
        /// <item>The primary value of the element.</item>
        /// <item>The secondary value of the element.</item>
        /// </list>
        /// </summary>
        Yes,
        /// <summary>
        /// It is known that this element does not match on either the primary or secondary value.
        /// </summary>
        NotValue,
        /// <summary>
        /// It is known that the element does not match the row.
        /// </summary>
        NotRow,
        /// <summary>
        /// It is known that the element does not match the column.
        /// </summary>
        NotColumn,
        /// <summary>
        /// It is known that the element does not match the column nor the row.
        /// </summary>
        NeitherRowNorColumn
    }
}
