using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests.Cells
{
    class GroundTesting
    {
        private int _x=0, _y=0;
        private Ground _ground;
        [SetUp]
        public void SetUp()
        {
            _ground = new Ground(_x,_y);
        }
        [Test]
        public void CheckTryToStep()
        {
            Assert.IsTrue(_ground.TryToStep());
        }
    }
}
