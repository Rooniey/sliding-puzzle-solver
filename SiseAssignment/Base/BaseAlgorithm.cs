using System.Collections.Generic;
using DataContract;
using DataContract.Model;
using SiseAssignment.Helpers;

namespace SiseAssignment.Base
{
    public abstract class BaseAlgorithm : IPuzzleSolver
    {
        public HashSet<PuzzleState> StatesProcessed { get; }
        public IEqualityComparer<PuzzleState> StateComparer { get; }
        public int MaxTreeLevel { get; set; }
        public int StatesVisited { get; set; }

        protected BaseAlgorithm()
        {
            StateComparer = new PuzzleStateComparer();
            StatesProcessed = new HashSet<PuzzleState>(StateComparer);
            MaxTreeLevel = 0;
            StatesVisited = 0;
        }

        public SolvingProcessData SolvePuzzle(PuzzleState initialState)
        {
            InitializeStructures(initialState);

            while (StatesToProcessExist())
            {
                var processedState = GetNextUnprocessedState();

                if (processedState.IsSolved())
                {
                    return new SolvingProcessData(
                        processedState.Path,
                        StatesVisited,
                        StatesProcessed.Count,
                        MaxTreeLevel);
                }

                List<MoveDirection> possibleMoves = processedState.PossibleMoves();

                EnqueueChildStates(processedState, possibleMoves);

                StatesProcessed.Add(processedState);
            }

            return new SolvingProcessData(
                null,
                StatesVisited,
                StatesProcessed.Count,
                MaxTreeLevel);
        }

        public abstract void InitializeStructures(PuzzleState initialState);
        public abstract bool StatesToProcessExist();
        public abstract PuzzleState GetNextUnprocessedState();
        public abstract void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves);
    }
}