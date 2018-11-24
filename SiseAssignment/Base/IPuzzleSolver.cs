using DataContract.Model;

namespace SiseAssignment.Base
{
    public interface IPuzzleSolver
    {
        SolvingProcessData SolvePuzzle(PuzzleState initialState);
    }
}