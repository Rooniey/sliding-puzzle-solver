using FifteenConsole.Extensions;
using SiseAssignment.Base;
using SiseAssignment.Implementations;

namespace FifteenConsole
{
    public class AlgorithmFactory
    {
        public static IPuzzleSolver GetAlgorithm(string algorithmName, string algorithmStrategy)
        {
            int maxRecursion = 25;

            IPuzzleSolver solver;
            switch (algorithmName)
            {
                case "bfs":
                {
                    solver = new BfsAlgorithm(algorithmStrategy.GetMoveDirection());
                    break;

                }
                case "dfs":
                {
                    solver = new DfsAlgorithm(algorithmStrategy.GetMoveDirection(), maxRecursion);
                    break;

                }
                case "astr":
                {
                    if (algorithmStrategy == "hamm")
                        solver = new AStarAlgorithm(new HammingsHeuristic());
                    else
                        solver = new AStarAlgorithm(new ManhattanHeuristic());
                        break;

                }
                default:
                {
                    solver = new BfsAlgorithm(algorithmStrategy.GetMoveDirection());
                    break;
                }

            }

            return solver;
        }
    }
}
