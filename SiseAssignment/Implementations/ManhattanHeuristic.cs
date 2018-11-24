using System;
using DataContract.Model;
using SiseAssignment.Base;

namespace SiseAssignment.Implementations
{
    public class ManhattanHeuristic : IHeuristic
    {
        public int CalculateHeuristic(PuzzleState current)
        {
            int displacement = 0;
            byte[] state = current.State;

            for (int i = 0; i < state.Length - 1; i++)
            {
                int currentValue = state[i];

                int absDiff = currentValue == 0 ? Math.Abs(i - state.Length - 1) : Math.Abs(i - state[i] - 1);

                displacement += absDiff / current.DimensionY;
                displacement += absDiff % current.DimensionY;
            }

            return displacement;
        }
    }
}
