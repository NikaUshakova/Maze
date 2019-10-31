using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests.Cells
{
    class CoordinatesTesting
    {
        private int _x = 0, _y = 0;
        private Coordinates _coordinates;
        [SetUp]
        public void SetUp()
        {
            _coordinates = new Coordinates(_x, _y);
        }
        [Test]
        public void CheckCoordinates()
        {
            Assert.AreEqual(_coordinates.X, _x);
            Assert.AreEqual(_coordinates.Y, _y);
        }

    }
}
