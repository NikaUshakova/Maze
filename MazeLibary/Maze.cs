using System;
using System.Collections.Generic;
using System.Linq;
using MazeLibrary.Cells;

namespace MazeLibrary
{
/// <summary>
/// Class contains maze work discription 
/// </summary>
    public class Maze: IMaze
    {
        /// <summary>
        /// maze height
        /// </summary>
        
        public int Height { get; }
        /// <summary>
        /// maze Width
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// position list
        /// </summary>
        public List<Ground> WithMoreThenOne = new List<Ground>();
        /// <summary>
        /// groud list
        /// </summary>
        public List<Ground> GroundCells = new List<Ground>();

        /// <summary>
        /// Maze construction algorithm
        /// </summary>
        /// <param name="height"> maze height </param>
        /// <param name="width">maze width </param>
        public Maze(int height, int width)
        {
            this.Height = height;
            this.Width = width;

            Random rnd = new Random();
                                 
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Cells.Add(new Wall(x, y));
                    GroundCells.Add(new Ground(x, y, true));


                }
            }
            for (int y = 0; y < Height; y += 2)
            {
                for (int x = 0; x + 1 < Width; x += 2)
                {
                    Cells[Cells.FindIndex(n => n.Coordinates.X == x & n.Coordinates.Y == y)] = new Ground(x, y);
                    GroundCells[GroundCells.FindIndex(n => n.Coordinates.X == x & n.Coordinates.Y == y)] = new Ground(x, y, false);
                }
            }


            WithMoreThenOne.Add(new Ground(0, 0, true));
            int positionX = 0;
            int positionY = 0;
            List<string> dir = new List<string>(4);

            while (WithMoreThenOne.Count > 0)
            {
                if (positionX+3 <= Width && GroundCells[GroundCells.FindIndex(n => n.Coordinates.X == positionX + 2 & n.Coordinates.Y == positionY)].Visited == false)
                {
                    dir.Add("Right");
                }
                if (positionX >= 2 && GroundCells[GroundCells.FindIndex(n => n.Coordinates.X == positionX - 2 & n.Coordinates.Y == positionY)].Visited == false)
                {
                    dir.Add("Left");
                }
                if (positionY+2 <= Height && GroundCells[GroundCells.FindIndex(n => n.Coordinates.X == positionX & n.Coordinates.Y == positionY + 2)].Visited == false)
                {
                    dir.Add("Down");
                }
                if (positionY >= 2 && GroundCells[GroundCells.FindIndex(n => n.Coordinates.X == positionX & n.Coordinates.Y == positionY - 2)].Visited == false)
                {
                    dir.Add("Up");
                }

                if(dir.Count>1 && (positionX !=0) && (positionY!=0))
                {
                    WithMoreThenOne.Add(new Ground(positionX, positionY, true));
                }

                if (dir.Count >= 1)
                {
                    switch (dir[rnd.Next(0, dir.Count)])
                    {
                        case "Right":
                            {
                                DoStep(positionX + 1, positionY, 1, 0);
                                positionX += 2;
                                break;
                            }
                        case "Left":
                            {
                                DoStep(positionX - 1, positionY, -1, 0);
                                positionX -= 2;
                                break;
                            }
                        case "Up":
                            {
                                DoStep(positionX, positionY - 1, 0, -1);
                                positionY -= 2;
                                break;
                            }
                        case "Down":
                            {
                                DoStep(positionX, positionY + 1, 0, 1);
                                positionY += 2;
                                break;
                            }
                    }
                }

                else
                {
                    positionX = WithMoreThenOne[WithMoreThenOne.Count - 1].Coordinates.X;
                    positionY = WithMoreThenOne[WithMoreThenOne.Count - 1].Coordinates.Y;
                    WithMoreThenOne.RemoveAt(WithMoreThenOne.Count-1);
                }

                dir.Clear();
            }
                        
        }
            public void DoStep(int x, int y, int i, int j)
            {
                Cells[Cells.FindIndex(n => n.Coordinates.X == x & n.Coordinates.Y == y)] = new Ground(x, y, true);
                GroundCells[GroundCells.FindIndex(n => n.Coordinates.X == x + i & n.Coordinates.Y == y + j)].Visited = true;
            }
      
        public List<BaseCell> Cells { get; } = new List<BaseCell>();
               
        /// <summary>
        /// chooses a path, that hero follows
        /// </summary>
        /// <param name="direction"> reference on moving direction </param>
        public void TryToStep(Direction direction)
        {
            BaseCell cellToMove = null;

            var hero = Player.GetPlayer;

            switch (direction)
            {
                case Direction.Up:
                    cellToMove = this[hero.Coordinates.X, hero.Coordinates.Y - 1];
                    break;
                case Direction.Right:
                    cellToMove = this[hero.Coordinates.X + 1, hero.Coordinates.Y ];
                    break;
                case Direction.Down:
                    cellToMove = this[hero.Coordinates.X, hero.Coordinates.Y + 1];
                    break;
                case Direction.Left:
                    cellToMove = this[hero.Coordinates.X - 1, hero.Coordinates.Y];
                    break;
            }

            if (cellToMove?.TryToStep() ?? false)
            {
                hero.Coordinates = cellToMove.Coordinates;
            }
        }
        /// <summary>
        /// 
         /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public BaseCell this[int x, int y]
        {
            //var cell = Maze[1,2];
            get
            {
                return Cells.SingleOrDefault(cell => cell.Coordinates.X == x && cell.Coordinates.Y == y);
            }

            //Maze[1,2] = new Wall(1,2);
            set
            {
                var oldCell = this[value.Coordinates.X, value.Coordinates.Y];
                if (oldCell != null)
                {
                    Cells.Remove(oldCell);
                }
                Cells.Add(value);
            }
        }
    }
}
