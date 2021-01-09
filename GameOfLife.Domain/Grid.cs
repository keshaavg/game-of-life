using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Domain
{
    public class Grid
    {
        public Grid()
        {

        }
        public string[] NextGeneration(string[] currentGeneration, int rowCount, int columnCount)
        {
            // Convert string array to 2d grid
            var grid = new char[rowCount, columnCount];
            for (int r = 0; r < rowCount; r++)
            {
                var columns = currentGeneration[r].ToCharArray();
                for (int k = 0; k < columnCount; k++)
                {
                    grid[r, k] = columns[k];
                }
            }

            // Evaluate and update next genration for each cell in grid
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    var cell = new Cell(grid[i, j]);
                    var neighbours = FindNeighbours(rowCount, columnCount, grid, i, j);
                    grid[i, j] = cell.Evaluate(neighbours.ToArray());

                }
            }

            // Convert 2d array back to string array
            var nextGeneration = new List<string>();
            for (int r = 0; r < rowCount; r++)
            {
                var row = new StringBuilder();
                for (int k = 0; k < columnCount; k++)
                {
                    row.Append(grid[r, k]);
                }
                nextGeneration.Add(row.ToString());
            }

            return nextGeneration.ToArray();
        }

        private static List<char> FindNeighbours(int rowCount, int columnCount, char[,] grid, int x, int y)
        {
            List<char> neighbours = new List<char>();
            // All possible neighbour index in 2 dimensional array
            var neighboursIndex = new List<(int, int)>
            {
                (x, y-1),
                (x, y+1),
                (x-1, y),
                (x-1, y-1),
                (x-1, y+1),
                (x+1, y),
                (x+1, y-1),
                (x+1, y+1),

            };

            foreach (var index in neighboursIndex)
            {
                // Ignore out of bound neighbour indexes
                if (index.Item1 < 0
                    || index.Item2 < 0
                    || index.Item1 >= rowCount
                    || index.Item2 >= columnCount
                    || (index.Item1 == x && index.Item2 == y)) continue;

                neighbours.Add(grid[index.Item1, index.Item2]);
            }

            return neighbours;
        }
    }
}
