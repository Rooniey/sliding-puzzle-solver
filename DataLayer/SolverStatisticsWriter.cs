using System.IO;
using DataContract.Model;

namespace DataLayer
{
    public static class SolverStatisticsWriter
    {

        public static void WriteStatisticsToFile(SolvingProcessData statistics, string path)
        {
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine(statistics.SolutionLength);
                outputFile.WriteLine(statistics.StatesVisited);
                outputFile.WriteLine(statistics.StatesProcessed);
                outputFile.WriteLine(statistics.MaxDepth);
                outputFile.WriteLine(statistics.Duration.ToString("F3"));
            }
        }

    }
}
