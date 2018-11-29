using System;
using System.Collections.Generic;

namespace DataContract.Model
{
    public class PuzzleState
    {
        public byte DimensionX { get; }
        public byte DimensionY { get; }
        public byte[] State { get; }
        public List<MoveDirection> Path { get; }
        public int PathLength { get; }
        public MoveDirection LastMove { get; }
        public int ZeroIndex { get; }


        #region CONSTRUCTORS

        public PuzzleState(byte dimensionX, byte dimensionY, byte[] state)
        {
            DimensionX = dimensionX;
            DimensionY = dimensionY;
            State = state ?? throw new ArgumentNullException(nameof(state));
            LastMove = MoveDirection.None;
            Path = new List<MoveDirection>();
            PathLength = 0;
            ZeroIndex = GetZeroIndex();
        }

        private PuzzleState(PuzzleState prev, byte[] newState, MoveDirection lastMove, int newZeroIndex)
        {
            DimensionX = prev.DimensionX;
            DimensionY = prev.DimensionY;
            State = newState;
            LastMove = lastMove;
            Path = new List<MoveDirection>(prev.Path) {lastMove};
            PathLength = Path.Count;
            ZeroIndex = newZeroIndex;
        }

        #endregion

        private int GetZeroIndex()
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
            if (State[State.Length - 1] != 0) return false;
            for(int i = 0; i < State.Length - 1; i++)
            {
                if (State[i] != (i + 1)) return false;
            }
            return true;
        }

        public List<MoveDirection> PossibleMoves()
        {
            List<MoveDirection> possibleMoves = new List<MoveDirection>();

            if (ZeroIndex % DimensionY != DimensionY - 1 && LastMove != MoveDirection.Left)
                possibleMoves.Add(MoveDirection.Right);

            if (ZeroIndex % DimensionY != 0 && LastMove != MoveDirection.Right) 
                possibleMoves.Add(MoveDirection.Left);

            if ( (ZeroIndex / DimensionY) != 0 && LastMove != MoveDirection.Down) 
                possibleMoves.Add(MoveDirection.Up);

            if ( (ZeroIndex / DimensionY) != DimensionX - 1 && LastMove != MoveDirection.Up) 
                possibleMoves.Add(MoveDirection.Down);

            return possibleMoves;
        }

        public PuzzleState Move(MoveDirection direction)
        {
            byte[] childBytes = new byte[State.Length];
            Array.Copy(State, childBytes, State.Length);
            int newZeroIndex;

            switch (direction)
            {
                case MoveDirection.Left:
                    newZeroIndex = ZeroIndex - 1;
                    childBytes[ZeroIndex] = childBytes[newZeroIndex];
                    break;

                case MoveDirection.Up:
                    newZeroIndex = ZeroIndex - DimensionX;
                    childBytes[ZeroIndex] = childBytes[newZeroIndex];
                    break;

                case MoveDirection.Right:
                    newZeroIndex = ZeroIndex + 1;
                    childBytes[ZeroIndex] = childBytes[newZeroIndex];
                    break; 

                case MoveDirection.Down:
                    newZeroIndex = ZeroIndex + DimensionX;
                    childBytes[ZeroIndex] = childBytes[newZeroIndex];
                    break;

                default:
                    throw new ArgumentOutOfRangeException("The passed action is invalid");
            }

            childBytes[newZeroIndex] = 0;

            return new PuzzleState(this, childBytes, direction, newZeroIndex);
        }
    }
}