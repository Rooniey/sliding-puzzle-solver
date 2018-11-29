using System.Collections.Generic;
using System.IO;
using System.Text;
using DataContract;
using DataContract.Extensions;
using DataContract.Model;

namespace DataLayer
{
    public static class SolverStatisticsWriter
    {

        public static void WriteStatisticsToFile(SolvingProcessData statistics, long duration, string path)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.GetFullPath(path)))
            {
                if (statistics.Solution != null) outputFile.WriteLine(statistics.Solution.Count);
                else outputFile.WriteLine("-1");
                outputFile.WriteLine(statistics.StatesVisited);
                outputFile.WriteLine(statistics.StatesProcessed);
                outputFile.WriteLine(statistics.MaxDepth);
                outputFile.WriteLine(duration.ToString());
            }
        }

        public static void WriteSolutionToFile(List<MoveDirection> solution, string path)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.GetFullPath(path)))
            {
                if (solution == null)
                {
                    outputFile.WriteLine("-1");
                    return;
                }

                outputFile.WriteLine(solution.Count);
                foreach (var moveDirection in solution)
                {
                    outputFile.Write(moveDirection.ToShortString());
                }
            }
        }

    }
}
