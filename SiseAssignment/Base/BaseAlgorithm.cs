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
        public int StatesProcessedCount { get; set; }
        public int StatesVisitedCount { get; set; }

        public IEqualityComparer<PuzzleState> StateComparer { get; }
        public int MaxTreeLevel { get; set; }

        protected BaseAlgorithm()
        {
            StateComparer = new PuzzleStateComparer();
            StatesVisited = new HashSet<PuzzleState>(StateComparer);
            MaxTreeLevel = 0;
            StatesProcessedCount = 0;
            StatesVisitedCount = 0;
        }

        public SolvingProcessData SolvePuzzle(PuzzleState initialState)
        {
            InitializeContainers(initialState);
            StatesProcessedCount++;

            while (StatesToVisitExist())
            {
                PuzzleState currentState = GetNextState();

                if(ShouldSkipState(currentState)) continue;

                StatesVisited.Add(currentState);
                StatesVisitedCount++;

                MaxTreeLevel = Math.Max(MaxTreeLevel, currentState.PathLength);

                if (currentState.IsSolved())
                {
                    return new SolvingProcessData(
                        currentState.Path,
                        StatesVisitedCount,
                        StatesProcessedCount,
                        MaxTreeLevel);
                }

                List<MoveDirection> possibleMoves = currentState.PossibleMoves();

                EnqueueChildStates(currentState, possibleMoves);
            }

            return new SolvingProcessData(
                null,
                StatesVisitedCount,
                StatesProcessedCount,
                MaxTreeLevel);
        }

        public abstract void InitializeContainers(PuzzleState initialState);
        public abstract bool StatesToVisitExist();
        public abstract PuzzleState GetNextState();
        public abstract void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves);
        public virtual bool ShouldSkipState(PuzzleState childState)
        {
            return StatesVisited.Contains(childState);
        }
    }
}