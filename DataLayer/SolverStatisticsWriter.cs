using System.Collections.Generic;
using System.IO;
using System.Text;
using DataContract;
using DataContract.Helpers;
using DataContract.Model;

namespace DataLayer
{
    public static class SolverStatisticsWriter
    {

        public static void WriteStatisticsToFile(SolvingProcessData statistics, long duration, string path)
        {
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                if (statistics.Solution != null) outputFile.WriteLine(statistics.Solution.Count);
                else outputFile.WriteLine("-1");
                outputFile.WriteLine(statistics.StatesVisited);
                outputFile.WriteLine(statistics.StatesProcessed);
                outputFile.WriteLine(statistics.MaxDepth);
                outputFile.WriteLine(duration.ToString("F3"));
            }
        }

        public static void WriteSolutionToFile(List<MoveDirection> solution, string path)
        {


            using (StreamWriter outputFile = new StreamWriter(path))
            {
                if (solution == null)
                {
                    outputFile.WriteLine("-1");
                    return;
                }

                StringBuilder sb = new StringBuilder();

                foreach (var moveDirection in solution)
                {
                    sb.Append(moveDirection.ToShortString());
                }

                outputFile.WriteLine(sb.ToString());
                
            }
        }

    }
}
