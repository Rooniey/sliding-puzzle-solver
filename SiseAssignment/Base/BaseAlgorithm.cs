﻿using System;
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
                PuzzleState currentlyVisitedState = GetNextUnvisitedState();

                StatesVisited.Add(currentlyVisitedState);

                MaxTreeLevel = Math.Max(MaxTreeLevel, currentlyVisitedState.PathLength);

                if (currentlyVisitedState.IsSolved())
                {
                    return new SolvingProcessData(
                        currentlyVisitedState.Path,
                        StatesVisited.Count,
                        StatesProcessed,
                        MaxTreeLevel);
                }

                List<MoveDirection> possibleMoves = currentlyVisitedState.PossibleMoves();

                EnqueueChildStates(currentlyVisitedState, possibleMoves);
            }

            return new SolvingProcessData(
                null,
                StatesVisited.Count,
                StatesProcessed,
                MaxTreeLevel);
        }

        public abstract void InitializeContainers(PuzzleState initialState);
        public abstract bool StatesToProcessExist();
        public abstract PuzzleState GetNextUnvisitedState();
        public abstract void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves);
    }
}