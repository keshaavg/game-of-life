using System;
using System.Linq;

namespace GameOfLife.Domain
{
    public class Cell
    {
        public const char ALIVE = '*';
        public const char DEAD = '.';
        private char _value;

        public Cell(char cellStatus)
        {
            if (cellStatus != ALIVE && cellStatus != DEAD) throw new ArgumentOutOfRangeException(nameof(cellStatus));
            _value = cellStatus;
        }

        public char Evaluate(char[] neighbours)
        {
            var activeNeighbours = neighbours.Count(x => x == ALIVE);

            if (activeNeighbours < 2 || activeNeighbours > 3)
                return DEAD;

            if (_value == DEAD && activeNeighbours == 3)
                return ALIVE;

            return _value;
        }
    }
}
