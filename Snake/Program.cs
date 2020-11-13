using ConsoleExtender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static int fps = 30;
        static int timeoutBasedOnFps;
        static int score = 0;
        static int rows = 25;
        static int columns = 50;
        static Player Player;
        static void Main(string[] args)
        {
            InitGame();
        }
        static void InitGame()
        {
            Console.WriteLine($"Press any key to start");
            Console.ReadKey();
            Console.Clear();
            Player = new Player(columns, rows);
            timeoutBasedOnFps = 1000 / fps;
            Task.Run(() => RenderBoard());
            Task.Run(() => RunGame());
            GetInput();
        }
        static void RenderBoard()
        {
            Console.CursorVisible = false;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"SCORE: {score}");

                for (int row = 0; row < rows; row++)
                {
                    string text = "";
                    for (int col = 0; col < columns; col++)
                    {
                        if (Player.Head.Equals(new Position(col, row)))
                        {
                            text += "0";
                        }
                        else if (Player.BodyParts.Any(x => x.Equals(new Position(col, row)))) // todo Fix rendering of snake. Player.BodyParts are shared across threads
                        {
                            text += "O";
                        }
                        else
                        {
                            text += " ";
                        }
                    }
                    Console.WriteLine(text);
                }
                Thread.Sleep(timeoutBasedOnFps);
            }
        }
        static void RunGame()
        {
            while (true)
            {
                Player.Move();
                Thread.Sleep(200);
            }
        }
        static void GetInput()
        {
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                Player.ChangeDirection(key);
            }
        }
    }
}
