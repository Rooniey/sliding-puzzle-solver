using System.Linq;

namespace DataContract.Model
{
    public class PuzzleState
    {
        public byte DimensionX { get; set; }
        public byte DimensionY { get; set; }
        public byte[] State { get; set; }

        public bool IsSolved()
        {
            for(int i = 0; i < State.Length; i++)
            {
                if (State[i] != (i + 1) % State.Length) return false;
            }
            return true;
        }

        public string PossibleMoves(int zeroIndex)
        {
            if (zeroIndex == 0) return "RD";
            if (zeroIndex == DimensionX - 1) return "LD";
            if (zeroIndex == DimensionX * (DimensionY - 1) - 1) return "UR";
            if (zeroIndex == State.Length - 1) return "LU";
            
            if (zeroIndex < DimensionX && zeroIndex > 0) return "LRD";
            if (zeroIndex % DimensionX == 0 && zeroIndex != 0 && zeroIndex != DimensionX * (DimensionY - 1) - 1) return "URD";
            var revLen = State.Length - zeroIndex;
            if (revLen % DimensionX == 0 && revLen != 0 && revLen != DimensionX * (DimensionY - 1) - 1) return "LUD";
            if (revLen < DimensionX && revLen > 0) return "LUR";

            return "LURD";
        }

        public void MoveLeft(int zeroIndex)
        {
            State[zeroIndex] = State[zeroIndex - 1];
            State[zeroIndex - 1] = 0;
        }

        public void MoveRight(int zeroIndex)
        {
            State[zeroIndex] = State[zeroIndex + 1];
            State[zeroIndex + 1] = 0;
        }

        public void MoveUp(int zeroIndex)
        {
            State[zeroIndex] = State[zeroIndex - DimensionX];
            State[zeroIndex - DimensionX] = 0;
        }

        public void MoveDown(int zeroIndex)
        {
            State[zeroIndex] = State[zeroIndex + DimensionX];
            State[zeroIndex + DimensionX] = 0;
        }
    }
}