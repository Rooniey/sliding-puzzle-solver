using System;
using DataContract.Extensions;
using SiseAssignment.Base;
using SiseAssignment.Heuristics;
using SiseAssignment.Implementations;

namespace FifteenConsole
{
    public static class AlgorithmFactory
    {
        public static readonly int MAX_RECURSION = 25;

        public static IPuzzleSolver GetAlgorithm(string algorithmName, string algorithmStrategy)
        {
            switch (algorithmName)
            {
                case "bfs":
                {
                    return new BfsAlgorithm(algorithmStrategy.GetMovePriorityArray());
                }
                case "dfs":
                {
                    return new DfsAlgorithm(algorithmStrategy.GetMovePriorityArray(), MAX_RECURSION);
                }
                case "astr":
                {
                    if (algorithmStrategy == "hamm")
                        return new AStarAlgorithm(new HammingsHeuristic());
                    else if(algorithmStrategy == "manh")
                        return new AStarAlgorithm(new ManhattanHeuristic());
                    else 
                        throw new ArgumentException($"Unknow heuristic used - {algorithmStrategy}");
                }
                default:
                {
                    throw new ArgumentException($"Unknow algorithm name - {algorithmName}");
                }

            }
        }
    }
}
