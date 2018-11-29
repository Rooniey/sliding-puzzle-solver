using System;
using System.Collections.Generic;
using System.Linq;
using DataContract;
using DataContract.Model;
using SiseAssignment.Base;

namespace SiseAssignment.Implementations
{
    public class DfsAlgorithm : BaseAlgorithm
    {
        private readonly MoveDirection[] _priority;

        private readonly int _maxDepth;

        public Stack<PuzzleState> StatesToProcess { get; }

        public DfsAlgorithm(MoveDirection[] priority, int maxDepth)
        {
            _priority = priority.Reverse().ToArray();
            _maxDepth = maxDepth;
            StatesToProcess = new Stack<PuzzleState>();
        }

        public override void InitializeContainers(PuzzleState initialState)
        {
            StatesToProcess.Push(initialState);
            StatesProcessed++;
        }

        public override bool StatesToProcessExist()
        {
            return StatesToProcess.Count != 0;
        }

        public override PuzzleState GetNextState()
        {
            return StatesToProcess.Pop();
        }

        public override void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves)
        {
            if (parentState.PathLength >= _maxDepth) return;

            foreach (var moveDirection in _priority.Where(possibleMoves.Contains))
            {
                PuzzleState childState = parentState.Move(moveDirection);
                StatesProcessed++;

                if (StatesVisited.Contains(childState))
                    continue;

                StatesToProcess.Push(childState);
            }
        }
    }
}
