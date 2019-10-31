using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary;
using NUnit.Framework;

namespace MazeLibrary.Tests
{
    class MazeTesting
    {
        int _height = 0, _width = 0;
        
        Maze _maze;
        [SetUp]
        public void SetUp()
        {
            _maze = new Maze(_height, _width);
        }
        [Test]
        public void CheckMaze()
        {
            Assert.AreEqual(_maze.Height, _height);
            Assert.AreEqual(_maze.Width, _width);
            
        }
      


    }
}
