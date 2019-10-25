using System;
using System.Collections.Generic;
using System.Text;

namespace MazeLibrary
{
    interface IMaze
    {
        int Height { get;  }
        int Width { get; }
        void DoStep(int x, int y, int i, int j);
        void TryToStep(Direction direction);


    }
}
                