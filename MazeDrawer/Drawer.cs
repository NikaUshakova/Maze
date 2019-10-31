using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary;


namespace MazeDrawer
{
    public static class Drawer
    {

        public static string Create(Maze maze)
        {
            var mazeStr = new StringBuilder(120);

            var hero = Player.GetPlayer;


            for (var i = 0; i < maze.Width + 1; i++)
            {
                mazeStr.Append("-");
            }

            for (var i = 0; i < maze.Height; i++)
            {
                mazeStr.AppendLine();
                mazeStr.Append("|");

                for (var j = 0; j < maze.Width; j++)
                {
                    if (hero.Coordinates.X == j && hero.Coordinates.Y == i)
                    {
                        mazeStr.Append(hero.Skin);
                    }
                    else
                    {

                        mazeStr.Append(maze[j, i].Skin);
                        //if (Math.Abs((j - hero.Coordinates.X)) < 3 && Math.Abs((i - hero.Coordinates.Y)) < 2)
                        //{
                        //    mazeStr.Append(maze[j, i].Skin);
                        //}
                        //else
                        //{
                        //    mazeStr.Append("N");
                        //}



                    }
                }
                mazeStr.Append("|");
            }



            mazeStr.AppendLine();
            for (var i = 0; i < maze.Width+2; i++)
            {
                mazeStr.Append("-");
            }

            return mazeStr.ToString();
        }



        
    }



}
