using DataContract.Model;

namespace SiseAssignment.Base
{
    public interface IHeuristic
    {
        int CalculateHeuristic(PuzzleState currentState);
    }
}
