using System;
using System.Collections.Generic;
using System.Linq;
using DataContract;
using DataContract.Model;
using SiseAssignment.Base;

namespace SiseAssignment.Implementations
{
    public class BfsAlgorithm : BaseAlgorithm
    {
        private readonly MoveDirection[] _priority;
        public Queue<PuzzleState> StatesToProcess { get; }

        public BfsAlgorithm(MoveDirection[] priorityMoves)
        {
            _priority = priorityMoves ?? throw new ArgumentNullException(nameof(priorityMoves));

            StatesToProcess = new Queue<PuzzleState>();
        }

        public override void InitializeStructures(PuzzleState initialState)
        {
            StatesToProcess.Enqueue(initialState);
            StatesVisited++;
        }

        public override PuzzleState GetNextState()
        {

            while (StatesProcessed.Contains(StatesToProcess.Peek()))
            {
                StatesToProcess.Dequeue();
            }
            return StatesToProcess.Dequeue();
        }

        public override bool StatesToProcessExist()
        {
            return StatesToProcess.Count != 0;
        }

        public override void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves)
        {
            MaxTreeLevel = Math.Max(MaxTreeLevel, parentState.PathLength);

            foreach (var moveDirection in _priority.Where(possibleMoves.Contains))
            {
                var childState = parentState.Move(moveDirection);
                StatesVisited++;

                if (StatesProcessed.Contains(childState))
                    continue;

                StatesToProcess.Enqueue(childState);
            }
        }
    }
}
