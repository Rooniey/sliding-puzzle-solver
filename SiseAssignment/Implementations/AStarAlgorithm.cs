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
        private readonly SortedList<int, PuzzleState> priorityList;
        private readonly IHeuristic _heuristic;

        public AStarAlgorithm(IHeuristic heuristic)
        {
            _heuristic = heuristic;
            priorityList = new SortedList<int, PuzzleState>(new PriorityComparer());
        }

        public override void InitializeStructures(PuzzleState initialState)
        {
            priorityList.Add(_heuristic.CalculateHeuristic(initialState) ,initialState);
            StatesVisited++;
        }

        public override bool StatesToProcessExist()
        {
            return priorityList.Count != 0;
        }

        public override PuzzleState GetNextState()
        {
            while (StatesProcessed.Contains(priorityList[0]))
            {
                priorityList.RemoveAt(0);
            }

            PuzzleState state = priorityList[0];
            priorityList.RemoveAt(0);

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

                priorityList.Add(child.PathLength + _heuristic.CalculateHeuristic(child), child);
            }
        }
    }
}
