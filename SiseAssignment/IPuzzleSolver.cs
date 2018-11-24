using DataContract.Model;

namespace SiseAssignment
{
    public interface IPuzzleSolver
    {
        string SolvePuzzle(PuzzleState initialState);
    }
}