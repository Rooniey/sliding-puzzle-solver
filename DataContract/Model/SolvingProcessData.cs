using System.Collections.Generic;

namespace DataContract.Model
{
    public class SolvingProcessData
    {
        public SolvingProcessData(List<MoveDirection> solution, int statesVisited, int statesProcessed, int maxDepth)
        {
            Solution = solution;
            StatesVisited = statesVisited;
            StatesProcessed = statesProcessed;
            MaxDepth = maxDepth;
        }

        public List<MoveDirection> Solution { get; }
        public int StatesVisited { get; }
        public int StatesProcessed { get; }
        public int MaxDepth { get; }
    }
}
