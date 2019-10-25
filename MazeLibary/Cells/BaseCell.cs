using System;
using System.Collections.Generic;
using System.Text;

namespace MazeLibrary.Cells
{
    public abstract class BaseCell : IBaseCell
    {
        public Coordinates Coordinates { get; set; }
        public char Skin { get;  set; }
        
        protected BaseCell(Coordinates coordinates, char skin)
        {
            Coordinates = coordinates;
            Skin = skin;
        }

        protected BaseCell(int x, int y, char skin)
        {
            Coordinates = new Coordinates(x, y);
            Skin = skin;
        }
        
        public abstract bool TryToStep();



    }
}
