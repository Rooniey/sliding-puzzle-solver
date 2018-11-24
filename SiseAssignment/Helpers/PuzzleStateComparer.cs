using System.Collections.Generic;
using DataContract.Model;

namespace SiseAssignment.Helpers
{
    public class PuzzleStateComparer : IEqualityComparer<PuzzleState>
    {
        public bool Equals(PuzzleState x, PuzzleState y)
        {
            byte[] xState = x.State;
            byte[] yState = y.State;

            if (x.DimensionX != y.DimensionX || x.DimensionY != y.DimensionY)
                return false;

            for (int i = 0; i < xState.Length; i++)
            {
                if (xState[i] != yState[i]) return false;
            }

            return true;
        }

        public int GetHashCode(PuzzleState obj)
        {
            byte[] state = obj.State;
            if (state == null) return 0;
            if (state.Length == 0) return -1;
            unchecked
            {
                const int p = 16777619;
                int hash = (int)2166136261;

                for (int i = 0; i < state.Length; i++)
                    hash = (hash ^ state[i] ^ i) * p;

                hash += hash << 13;
                hash ^= hash >> 7;
                hash += hash << 3;
                hash ^= hash >> 17;
                hash += hash << 5;

                return hash;
            }
        }
    }
}
