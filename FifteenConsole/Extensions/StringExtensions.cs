using System;
using System.Linq;
using DataContract;

namespace FifteenConsole.Extensions
{
    public static class StringExtensions
    {
        public static char[] PossibleMoves = new char[] {'L', 'U', 'R', 'D'};

        public static MoveDirection[] GetMoveDirection(this string strategy)
        {
            if(strategy.Any(m => !PossibleMoves.Contains(m))) 
                throw new ArgumentException("Improper move priority strategy");

            MoveDirection[] possibleDirections = new MoveDirection[4];

            for (int i = 0; i < 4; i++)
            {
                switch (strategy[i])
                {
                    case 'L':
                        possibleDirections[i] = MoveDirection.Left;
                        break;
                    case 'U':
                        possibleDirections[i] = MoveDirection.Up;
                        break;
                    case 'R':
                        possibleDirections[i] = MoveDirection.Right;
                        break;
                    case 'D':
                        possibleDirections[i] = MoveDirection.Down;
                        break;
                }
            }

            return possibleDirections;
        }
    }
}

