using System;


namespace Life
{
    // Life -   provides a container and some functionality for calculating states
    //          for Conway's Game of Life
    class Life
    {
        // constructor
        public Life(int h, int w)
        {
            if (h <= 0 || w <= 0)
                throw new ArgumentOutOfRangeException("Dimensions must be positive!");

            Height = h;
            Width = w;
            Ticks = 0;
            Grid = new bool[h, w];
        }

        // properties
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Ticks { get; set; }
        private bool[,] Grid { get; set; }

        // indexer
        public bool this[int y, int x]
        {
            get
            {
                if (IsOutOfBounds(y, x))
                    throw new ArgumentOutOfRangeException("Coordinates must be non-negative!");

                return Grid[y, x];
            }

            set
            {
                if (IsOutOfBounds(y, x))
                    throw new ArgumentOutOfRangeException("Coordinates must be non-negative!");

                Grid[y, x] = value;
            }
        }

        // tick -   calculates and brings class to next generational state
        public void Tick()
        {
            bool[,] clone = GetClonedBoard();

            for (var j = 0; j < Height; ++j)
                for (var i = 0; i < Width; ++i)
                    clone[j, i] = GetNextState(j, i);

            Grid = clone;
            ++Ticks;
        }

        private bool IsOutOfBounds(int y, int x)
        {
            return y < 0 || y >= Height || x < 0 || x >= Width;
        }

        // determines number of live (true) cells are directly adjacent to given cell
        private int GetLiveNeighbours(int y, int x)
        {
            if (IsOutOfBounds(y, x))
                throw new ArgumentOutOfRangeException("Coordinates must be non-negative!");

            int count = 0;

            for (var j = y - 1; j < y + 2; ++j)
                for (var i = x - 1; i < x + 2; ++i)
                    if (!IsOutOfBounds(j, i))
                        count += Convert.ToInt32(Grid[j, i]);

            return count - Convert.ToInt32(Grid[y, x]);
        }

        // determines next state of a given cell
        private bool GetNextState(int y, int x)
        {
            if (IsOutOfBounds(y, x))
                throw new ArgumentOutOfRangeException("Coordinates must be non-negative!");

            switch (GetLiveNeighbours(y, x))
            {
                case 2:
                    return Grid[y, x];      // a live cell will continue living
                case 3:
                    return true;            // a dead cell will become a live, a live cell will continue living
                default:
                    return false;
            }
        }

        // generates deep clone of entire board
        private bool[,] GetClonedBoard()
        {
            bool[,] clone = new bool[Height, Width];

            for (var j = 0; j < Height; ++j)
                for (var i = 0; i < Width; ++i)
                    clone[j, i] = Grid[j, i];

            return clone;
        }
    }
}