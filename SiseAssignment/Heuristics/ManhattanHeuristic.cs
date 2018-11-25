using System;
using DataContract.Model;
using SiseAssignment.Base;

namespace SiseAssignment.Heuristics
{
    public class ManhattanHeuristic : IHeuristic
    {
        public int CalculateHeuristic(PuzzleState current)
        {
            int displacementSum = 0;
            byte[] state = current.State;

            for (int i = 0; i < state.Length; i++)
            {
                int currentValue = state[i];

                int correctPosition = currentValue == 0 ? state.Length - 1 : currentValue - 1;

                displacementSum += Math.Abs(i / current.DimensionY - correctPosition / current.DimensionY);
                displacementSum += Math.Abs(i % current.DimensionY - correctPosition % current.DimensionY);
            }

            return displacementSum;
        }
    }
}
