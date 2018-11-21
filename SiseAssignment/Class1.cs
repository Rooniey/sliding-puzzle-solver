using DataContract.Model;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiseAssignment
{
    public class Class1
    {
        public static int MAX_DEPTH = 25;

        public void SolveBFS(string strategy, string inputFilePath, string solutionFilePath, string statisticsFilePath)
        {
            PuzzleState initialState = InitialStateReader.ReadStateFromFile(inputFilePath);

            var index = 0;
            foreach(var item in initialState.State)
            {
                if (item == 0) break;
                index++;
            }

            while(!initialState.IsSolved())
            {
                foreach(char item in strategy.Where(e => initialState.PossibleMoves(index).Contains(e)))
                {
                    switch(item)
                    {
                        case 'L':
                            initialState.MoveLeft(index);
                            break;
                        case 'U':
                            initialState.MoveUp(index);
                            break;
                        case 'R':
                            initialState.MoveRight(index);
                            break;
                        case 'D':
                            initialState.MoveDown(index);
                            break;
                    }
                }
            }
        }
    }
}
