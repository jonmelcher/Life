// ***************************************************************************
//  filename:   Life.cs
//  purpose:    contains Life class for calculating states during a session of
//              Conway's Game of Life
//
//  written by Jonathan Melcher
//  last updated 02/20/2016
// ***************************************************************************


using System;


namespace Life
{
    // ***********************************************************************************
    //  class       -   class Life
    //  puurpose    -   provides a container and some functionality for calculating states   
    //                  during a session of Conway's Game of Life
    //  API         -   Life(int, int)      -   constructor -   O(hw)
    //                  int Height get      -   property    -   O(1)
    //                  int Width get       -   property    -   O(1)
    //                  int Ticks get/set   -   property    -   O(1)
    //                  bool this[int, int] -   indexer     -   O(1)
    //                  Tick()              -   method      -   O(hw)
    // ***********************************************************************************
    class Life
    {
        // constructor
        // generates h x w grid of false values - grid cannot have non-positive values
        public Life(int h, int w)
        {
            if (h <= 0 || w <= 0)
                throw new ArgumentOutOfRangeException("Dimensions must be positive!");

            Height = h;
            Width = w;
            Ticks = 0;
            Grid = new bool[h, w];
        }

        public int Height { get; private set; }     // height of internal grid
        public int Width { get; private set; }      // width of internal grid
        public int Ticks { get; set; }              // label of current state
        private bool[,] Grid { get; set; }          // internal grid for game

        // indexer
        // allows get/set access to internal grid - coordinate validation occurs here
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

        // method - calculates and transitions class data into next generational state of game
        public void Tick()
        {
            // duplicate board to prevent a corrupt state
            bool[,] clone = GetClonedBoard();

            for (var j = 0; j < Height; ++j)
                for (var i = 0; i < Width; ++i)
                    clone[j, i] = GetNextState(j, i);

            // after state is completely calculated, assign it over to internal grid
            Grid = clone;
            ++Ticks;
        }

        // method - determines if given y, x coordinates are out of bounds of the internal grid
        private bool IsOutOfBounds(int y, int x)
        {
            return y < 0 || y >= Height || x < 0 || x >= Width;
        }

        // method - determines number of live (true) cells which are directly adjacent to cell at given coordinates
        private int GetLiveNeighbours(int y, int x)
        {
            // validate coordinates for cell
            if (IsOutOfBounds(y, x))
                throw new ArgumentOutOfRangeException("Coordinates must be non-negative!");

            int count = 0;

            for (var j = y - 1; j < y + 2; ++j)
                for (var i = x - 1; i < x + 2; ++i)
                    if (!IsOutOfBounds(j, i))
                        count += Convert.ToInt32(Grid[j, i]);

            return count - Convert.ToInt32(Grid[y, x]);
        }

        // method - determines next state of a cell at the given coordinates
        private bool GetNextState(int y, int x)
        {
            // validate coordinates for cell
            if (IsOutOfBounds(y, x))
                throw new ArgumentOutOfRangeException("Coordinates must be non-negative!");

            // apply Conway's Game of Life Logic
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

        // method - generates deep clone of entire board
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