using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests.Cells
{  
    class WallTesting
    {
        Wall _wall;
        int _x = 0,_y = 0;
        [SetUp]
        public void SetUp()
        {
            _wall = new Wall(_x, _y);
        }
        [Test]
        public void CheckTryToStep()
        {
            Assert.IsFalse(_wall.TryToStep());
           
        }
    }
}
