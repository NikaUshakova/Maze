using System;
using System.Collections.Generic;
using System.Text;

namespace MazeLibrary.Cells
{
    interface IBaseCell
    {
        Coordinates Coordinates { get; set; }
        char Skin { get;  set; }
         bool TryToStep();
    
    }
}
