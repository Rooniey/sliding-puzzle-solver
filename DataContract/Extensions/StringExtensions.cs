using System;
using System.Linq;

namespace DataContract.Extensions
{
    public static class StringExtensions
    {
        public static char[] PossibleMoves = new char[] {'L', 'U', 'R', 'D'};

        public static MoveDirection[] GetMovePriorityArray(this string strategy)
        {

            #region CONDITIONS
            if (strategy.Length != PossibleMoves.Length)
                throw new ArgumentException($"Improper length of priority strategy - {strategy}");
//
//            if (PossibleMoves.All(strategy.ToCharArray().Contains))
//                throw new ArgumentException($"Strategy contains unknown characters - {strategy}");
            #endregion

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

