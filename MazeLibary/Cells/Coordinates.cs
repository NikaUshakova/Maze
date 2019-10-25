using System;
using System.Collections.Generic;
using System.Text;

namespace MazeLibrary.Cells
{
    /// <summary>
    /// coordinates used in the maze
    /// </summary>
    public struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        
    }
}
