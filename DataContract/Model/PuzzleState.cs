using System;
using System.Collections.Generic;
using DataContract.Helpers;

namespace DataContract.Model
{
    public class PuzzleState
    {
        public byte DimensionX { get; }
        public byte DimensionY { get; }
        public byte[] State { get; }
        public string Path { get; }
        public MoveDirection LastMove { get; }

        // TODO Check if parent is necessary
        public PuzzleState Parent { get; }

        #region CONSTRUCTORS

        public PuzzleState(byte dimensionX, byte dimensionY, byte[] state)
        {
            DimensionX = dimensionX;
            DimensionY = dimensionY;
            State = state ?? throw new ArgumentNullException(nameof(state));
            LastMove = MoveDirection.None;
            Path = string.Empty;
        }

        private PuzzleState(byte dimensionX, byte dimensionY, byte[] newState, MoveDirection lastMove, PuzzleState prev)
        {
            DimensionX = dimensionX;
            DimensionY = dimensionY;
            State = newState;
            LastMove = lastMove;

            Path = prev.Path + lastMove.ToShortString();
            Parent = prev;
        }

        #endregion

        public int GetZeroIndex()
        {
            var index = 0;
            foreach (var item in State)
            {
                if (item == 0) break;
                index++;
            }

            return index;
        }

        public bool IsSolved()
        {
            for(int i = 0; i < State.Length; i++)
            {
                if (State[i] != (i + 1) % State.Length) return false;
            }
            return true;
        }

        public List<MoveDirection> PossibleMoves()
        {
            var zeroIndex = GetZeroIndex();
            List<MoveDirection> possibleMoves = new List<MoveDirection>();

            if (zeroIndex % DimensionY != DimensionY - 1 && LastMove != MoveDirection.Left)
                possibleMoves.Add(MoveDirection.Right);

            if (zeroIndex % DimensionY != 0 && LastMove != MoveDirection.Right) 
                possibleMoves.Add(MoveDirection.Left);

            if ( (zeroIndex / DimensionY) != 0 && LastMove != MoveDirection.Down) 
                possibleMoves.Add(MoveDirection.Up);

            if ( (zeroIndex / DimensionY) != DimensionX - 1 && LastMove != MoveDirection.Up) 
                possibleMoves.Add(MoveDirection.Down);

            return possibleMoves;

//            if (zeroIndex == 0) return "RD";
//            if (zeroIndex == DimensionX - 1) return "LD";
//            if (zeroIndex == DimensionX * (DimensionY - 1) - 1) return "UR";
//            if (zeroIndex == State.Length - 1) return "LU";
//            
//            if (zeroIndex < DimensionX && zeroIndex > 0) return "LRD";
//            if (zeroIndex % DimensionX == 0 && zeroIndex != 0 && zeroIndex != DimensionX * (DimensionY - 1) - 1) return "URD";
//            var revLen = State.Length - zeroIndex;
//            if (revLen % DimensionX == 0 && revLen != 0 && revLen != DimensionX * (DimensionY - 1) - 1) return "LUD";
//            if (revLen < DimensionX && revLen > 0) return "LUR";
//
//            return "LURD";
        }

        public PuzzleState Move(MoveDirection direction)
        {
            var zeroIndex = GetZeroIndex();

            byte[] childBytes = new byte[State.Length];
            Array.Copy(State, childBytes, State.Length);

            switch (direction)
            {
                case MoveDirection.Left:
                    childBytes[zeroIndex] = childBytes[zeroIndex - 1];
                    childBytes[zeroIndex - 1] = 0;
                    break;

                case MoveDirection.Up:
                    childBytes[zeroIndex] = childBytes[zeroIndex - DimensionX];
                    childBytes[zeroIndex - DimensionX] = 0;
                    break;

                case MoveDirection.Right:
                    childBytes[zeroIndex] = childBytes[zeroIndex + 1];
                    childBytes[zeroIndex + 1] = 0;
                    break; 

                case MoveDirection.Down:
                    childBytes[zeroIndex] = childBytes[zeroIndex + DimensionX];
                    childBytes[zeroIndex + DimensionX] = 0;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("The passed action is invalid");
            }

            return new PuzzleState(this.DimensionX, this.DimensionY, childBytes, direction, this);
        }
    }
}