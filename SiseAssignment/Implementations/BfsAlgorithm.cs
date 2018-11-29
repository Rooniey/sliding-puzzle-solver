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

        public override void InitializeContainers(PuzzleState initialState)
        {
            StatesToProcess.Enqueue(initialState);
        }

        public override PuzzleState GetNextState()
        {
            return StatesToProcess.Dequeue();
        }

        public override bool StatesToVisitExist()
        {
            return StatesToProcess.Count != 0;
        }

        public override void EnqueueChildStates(PuzzleState parentState, List<MoveDirection> possibleMoves)
        {
            foreach (var moveDirection in _priority.Where(possibleMoves.Contains))
            {
                PuzzleState childState = parentState.Move(moveDirection);
                StatesProcessedCount++;

                if (StatesVisited.Contains(childState))
                    continue;

                StatesToProcess.Enqueue(childState);
            }
        }
    }
}
