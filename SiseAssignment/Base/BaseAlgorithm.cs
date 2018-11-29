using System;
using System.Collections.Generic;
using DataContract;
using DataContract.Model;
using SiseAssignment.Helpers;

namespace SiseAssignment.Base
{
    public abstract class BaseAlgorithm : IPuzzleSolver
    {
        public HashSet<PuzzleState> StatesVisited { get; }
        public int StatesProcessed { get; set; }
        public IEqualityComparer<PuzzleState> StateComparer { get; }
        public int MaxTreeLevel { get; set; }

        protected BaseAlgorithm()
        {
            StateComparer = new PuzzleStateComparer();
            StatesVisited = new HashSet<PuzzleState>(StateComparer);
            MaxTreeLevel = 0;
            StatesProcessed = 0;
        }

        public SolvingProcessData SolvePuzzle(PuzzleState initialState)
        {
            InitializeContainers(initialState);

            while (StatesToProcessExist())
            {
                PuzzleState currentState = GetNextState();

                if(StatesVisited.Contains(currentState)) continue;

                StatesVisited.Add(currentState);

                MaxTreeLevel = Math.Max(MaxTreeLevel, currentState.PathLength);

                if (currentState.IsSolved())
                {
                    return new SolvingProcessData(
                        currentState.Path,
                        StatesVisited.Count,
                        StatesProcessed,
                        MaxTreeLevel);
                }

                List<MoveDirection> possibleMoves = currentState.PossibleMoves();

                EnqueueChildStates(currentState, possibleMoves);
            }

            return new SolvingProcessData(
                null,
                StatesVisited.Count,
                StatesProcessed,
                MaxTreeLevel);
        }

        public abstract void InitializeContainers(PuzzleState initialState);
        public abstract bool StatesToProcessExist();
        public abstract PuzzleState GetNextState();
        public abstract void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves);
    }
}