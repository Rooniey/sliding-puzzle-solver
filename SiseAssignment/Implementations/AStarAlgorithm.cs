﻿using System.Collections.Generic;
using DataContract;
using DataContract.Model;
using SiseAssignment.Base;
using SiseAssignment.Helpers;

namespace SiseAssignment.Implementations
{
    public class AStarAlgorithm : BaseAlgorithm
    {
        private readonly SortedList<int, PuzzleState> _priorityList;
        private readonly IHeuristic _heuristic;

        public AStarAlgorithm(IHeuristic heuristic)
        {
            _heuristic = heuristic;
            _priorityList = new SortedList<int, PuzzleState>(new PriorityComparer());
        }

        public override void InitializeContainers(PuzzleState initialState)
        {
            _priorityList.Add(_heuristic.CalculateHeuristic(initialState) ,initialState);
            StatesProcessed++;
        }

        public override bool StatesToProcessExist()
        {
            return _priorityList.Count != 0;
        }

        public override PuzzleState GetNextUnvisitedState()
        {
            while (StatesVisited.Contains(_priorityList.Values[0]))
            {
                _priorityList.RemoveAt(0);
            }

            PuzzleState state = _priorityList.Values[0];
            _priorityList.RemoveAt(0);

            return state;
        }

        public override void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves)
        {
            foreach (var moveDirection in possibleMoves)
            {
                PuzzleState child = parentState.Move(moveDirection);
                StatesProcessed++;

                if (StatesVisited.Contains(child))
                    continue;

                _priorityList.Add(child.PathLength + _heuristic.CalculateHeuristic(child), child);
            }
        }
    }
}
