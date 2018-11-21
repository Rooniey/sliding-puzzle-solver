namespace DataContract.Model
{
    public class SolvingProcessData
    {
        public SolvingProcessData(int solutionLength, int statesVisited, int statesProcessed, int maxDepth, double duration)
        {
            SolutionLength = solutionLength;
            StatesVisited = statesVisited;
            StatesProcessed = statesProcessed;
            MaxDepth = maxDepth;
            Duration = duration;
        }

        public int SolutionLength { get; }
        public int StatesVisited { get; }
        public int StatesProcessed { get; }
        public int MaxDepth { get; }
        public double Duration { get; }
    }
}
