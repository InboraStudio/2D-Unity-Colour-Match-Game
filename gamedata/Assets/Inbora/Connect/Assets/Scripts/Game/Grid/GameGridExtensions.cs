namespace Ilumisoft.Connect.Game
{
    using UnityEngine;

    /// <summary>
    /// Extension class of the game grid, containing some helper methods
    /// </summary>
    public static class GameGridExtensions
    {
        /// <summary>
        /// Gets the element of the grid in the given column and row 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static GameGridElement GetElement(this GameGrid grid, int column, int row)
        {
            return grid.Elements[row * grid.ColumnCount + column];
        }

        /// <summary>
        /// Gets the world position of the given position in the grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="column"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static Vector2 GridToWorldPosition(this GameGrid grid, int column, int row)
        {
            return grid.StartCellPosition + grid.CellSize * new Vector2(column, row);
        }

        /// <summary>
        /// Gets the world position of the given position in the grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="gridPos"></param>
        /// <returns></returns>
        public static Vector2 GridToWorldPosition(this GameGrid grid, Vector2Int gridPos)
        {
            return grid.GridToWorldPosition(gridPos.x, gridPos.y);
        }

        /// <summary>
        /// Gets the index of the element at the given grid position
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="gridPos"></param>
        /// <returns></returns>
        public static int GridPositionToIndex(this GameGrid grid, Vector2Int gridPos)
        {
            return grid.ColumnCount * gridPos.y + gridPos.x;
        }
    }
}