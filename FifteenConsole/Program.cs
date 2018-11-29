using System;
using System.Diagnostics;
using DataContract.Model;
using DataLayer;
using SiseAssignment.Base;

namespace FifteenConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 5)
            {
                IPuzzleSolver algorithm = AlgorithmFactory.GetAlgorithm(args[0], args[1]);

                var initialState = InitialStateReader.ReadStateFromFile(args[2]);

                Stopwatch sw = new Stopwatch();
                sw.Start();

                SolvingProcessData stats = algorithm.SolvePuzzle(initialState);

                sw.Stop();

                SolverStatisticsWriter.WriteSolutionToFile(stats.Solution, args[3]);
                SolverStatisticsWriter.WriteStatisticsToFile(stats, sw.ElapsedMilliseconds, args[4]);
            }       
        }
    }
}
