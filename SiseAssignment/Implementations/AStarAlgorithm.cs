using System;
using System.Collections.Generic;
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

        public override void InitializeStructures(PuzzleState initialState)
        {
            _priorityList.Add(_heuristic.CalculateHeuristic(initialState) ,initialState);
            StatesVisited++;
        }

        public override bool StatesToProcessExist()
        {
            return _priorityList.Count != 0;
        }

        public override PuzzleState GetNextUnprocessedState()
        {
            while (StatesProcessed.Contains(_priorityList[0]))
            {
                _priorityList.RemoveAt(0);
            }

            PuzzleState state = _priorityList[0];
            _priorityList.RemoveAt(0);

            return state;
        }

        public override void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves)
        {
            MaxTreeLevel = Math.Max(MaxTreeLevel, parentState.PathLength);

            foreach (var moveDirection in possibleMoves)
            {
                var child = parentState.Move(moveDirection);
                StatesVisited++;

                if (StatesProcessed.Contains(child))
                    continue;

                _priorityList.Add(child.PathLength + _heuristic.CalculateHeuristic(child), child);
            }
        }
    }
}
