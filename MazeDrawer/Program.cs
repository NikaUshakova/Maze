using System;
using MazeLibrary;

namespace MazeDrawer
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(13, 16);

            var instructions = "It is животное. He will help you find a way out (maybe baby) \n" +
                
                "\n" +
                "\n   @@@         @@@"  +
                "\n  @   @      @    @" +
                "\n   @@  @    @   @@" +
                "\n        @@@@                  @@@@" +
                "\n      @@    @@               @@   @@"+
                "\n     @  *  *  @                  @@@"+
                "\n      @@ ** @@   @@@@@@@@@     @@@ " +
                "\n        @@@@@@@@@         @@@@@" +
                "\n       @                      @@" +
                "\n      @        BAD MAZE        @@" +
                "\n      @@                      @@"+
                "\n       @@                   @@" +
                "\n          @@@@@@@@@@@@@@@@@@" +
                "\n            @@ @@     @@ @@    " +
                "\n           @@   @@   @@   @@ "+
                "\n          @@     @@ @@     @@ " +
                "\n" +
                "\n Клацай на стрелочки " +
                "\n ";

            var key = new ConsoleKeyInfo();
            Console.WriteLine(instructions + Drawer.Create(maze));
            while (key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey();
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                    {
                        maze.TryToStep(Direction.Up);
                        break;
                    }

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                    {
                        maze.TryToStep(Direction.Left);
                        break;
                    }

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                    {
                        maze.TryToStep(Direction.Right);
                        break;
                    }

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                    {
                        maze.TryToStep(Direction.Down);
                        break;
                    }
                }

                Console.WriteLine(instructions + Drawer.Create(maze));
            }
        }
    }
}
