using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Player
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Direction Direction { get; set; }
        public Position Head { get; set; }
        public List<Position> BodyParts { get; set; }
        public Player(int columns, int rows)
        {
            Direction = Direction.North;
            Rows = rows;
            Columns = columns;

            Head = new Position(columns / 2, rows / 2);
            BodyParts = new List<Position>(){
                new Position(Head.X, Head.Y + 1),
                new Position(Head.X, Head.Y + 2),
                new Position(Head.X, Head.Y + 3),
                new Position(Head.X, Head.Y + 4) };
        }
        public void ChangeDirection(ConsoleKey key)
        {
            Direction newDirection;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    newDirection = Direction.West;
                    break;
                case ConsoleKey.UpArrow:
                    newDirection = Direction.North;
                    break;
                case ConsoleKey.RightArrow:
                    newDirection = Direction.East;
                    break;
                case ConsoleKey.DownArrow:
                    newDirection = Direction.South;
                    break;
                default:
                    newDirection = Direction.NotSet;
                    break;
            }

            if ((int)newDirection + (int)Direction == 4 || (int)newDirection + (int)Direction == 6) // North(1) + South(3) == 4. East(2) + West(4) == 4.
            {
                return;
            }
            Direction = newDirection;
        }
        public bool Move()
        {
            Position newBodyPart = new Position(Head.X, Head.Y);
            switch (Direction)
            {
                case Direction.North:
                    Head = new Position(Head.X, Head.Y - 1);
                    break;
                case Direction.East:
                    Head = new Position(Head.X + 1, Head.Y);
                    break;
                case Direction.South:
                    Head = new Position(Head.X, Head.Y + 1);
                    break;
                case Direction.West:
                    Head = new Position(Head.X - 1, Head.Y);
                    break;
                default:
                    break;
            }

            if (BodyParts.Any(x => x.Equals(Head)))
            {
                return true;
            }

            BodyParts.Insert(0, newBodyPart);
            BodyParts.RemoveAt(BodyParts.Count - 1);
            return false;
        }

        //TODO Check collision
    }
    public class Head
    {
        public Position Position { get; set; }
        public Head(Position position)
        {
            Position = position;
        }
    }
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

    public enum Direction
    {
        NotSet,
        North,
        East,
        South,
        West
    }
}
