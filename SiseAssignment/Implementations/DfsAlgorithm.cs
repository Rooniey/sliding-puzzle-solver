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

        public override void InitializeStructures(PuzzleState initialState)
        {
            StatesToProcess.Push(initialState);
            StatesVisited++;
        }

        public override bool StatesToProcessExist()
        {
            return StatesToProcess.Count != 0;
        }

        public override PuzzleState GetNextState()
        {
            while (StatesProcessed.Contains(StatesToProcess.Peek()))
            {
                StatesToProcess.Pop();
            }
            return StatesToProcess.Pop();
        }

        public override void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves)
        {
            int currentTreeLevel = parentState.PathLength;
            if (currentTreeLevel >= _maxDepth) return;

            MaxTreeLevel = Math.Max(MaxTreeLevel, currentTreeLevel + 1);

            foreach (var moveDirection in _priority.Where(possibleMoves.Contains))
            {
                var childState = parentState.Move(moveDirection);
                StatesVisited++;

                if (StatesProcessed.Contains(childState))
                    continue;

                StatesToProcess.Push(childState);
            }
        }
    }
}
