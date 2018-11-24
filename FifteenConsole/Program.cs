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
            string path = @"..\..\DataHandler\Data\"; //todo datahandler


            IPuzzleSolver algorithm = AlgorithmFactory.GetAlgorithm(args[0], args[1]);

            var initialState = InitialStateReader.ReadStateFromFile(path + args[2]);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            SolvingProcessData stats = algorithm.SolvePuzzle(initialState);

            sw.Stop();
            
            SolverStatisticsWriter.WriteSolutionToFile(stats.Solution, args[3]);
            SolverStatisticsWriter.WriteStatisticsToFile(stats, sw.ElapsedMilliseconds, args[4]);
        }
    }
}
