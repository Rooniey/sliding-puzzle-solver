using System;
using DataContract.Model;
using System.Collections.Generic;
using System.Linq;
using DataContract;

namespace SiseAssignment
{
    public class BFSAlgorithm : IPuzzleSolver
    {
        private MoveDirection[] _priority;

        public BFSAlgorithm(MoveDirection[] priorityMoves)
        {
            _priority = priorityMoves ?? throw new ArgumentNullException(nameof(priorityMoves));
        }

        public string SolvePuzzle(PuzzleState initialState)
        {
            Queue<PuzzleState> statesToProcess = new Queue<PuzzleState>();

            Dictionary<string ,PuzzleState> statesProcessed = new Dictionary<string, PuzzleState>();

            statesToProcess.Enqueue(initialState);

            while(statesToProcess.Count != 0)
            {
                var processedState = statesToProcess.Dequeue();

                if (processedState.IsSolved()) return processedState.Path;

                List<MoveDirection> possibleMoves = processedState.PossibleMoves();

                foreach (var moveDirection in _priority.Where(m => possibleMoves.Contains(m)))
                {
                    var childState = processedState.Move(moveDirection);


                    // TODO check processed state, different paths can have the same state equality
                    if (statesProcessed.ContainsKey(childState.Path)) continue;

                    // TODO possible?
                    if (!statesToProcess.Any(e => e.Path == childState.Path))
                    {
                        statesToProcess.Enqueue(childState);
                    }
                }

                statesProcessed.Add(processedState.Path, processedState);
            }

            return null;
        }
    }
}
