using DataContract.Model;
using SiseAssignment.Base;

namespace SiseAssignment.Heuristics
{
    public class HammingsHeuristic : IHeuristic
    {
        public int CalculateHeuristic(PuzzleState current)
        {
            int incorrectOnes = 0;
            byte[] state = current.State;
            for (int i = 0; i < state.Length - 1; i++)
            {
                if (state[i] != (i + 1))
                    incorrectOnes++;
            }

            incorrectOnes += state[state.Length - 1] != 0 ? 1 : 0;

            return incorrectOnes;
        }
    }
}
