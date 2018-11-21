using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataContract.Model;

namespace DataLayer
{
    public static class InitialStateReader
    {
        public static PuzzleState ReadStateFromFile(string path)
        {
            PuzzleState state = new PuzzleState();
            using (StreamReader sr = new StreamReader(path))
            {
                var dimensions = sr.ReadLine().Split(' ', '\r', '\n');
                state.DimensionY = byte.Parse(dimensions[0]);
                state.DimensionX = byte.Parse(dimensions[1]);

                var stateValues = new List<byte>();

                for (int i = 0; i < state.DimensionX; i++)
                {
                    stateValues.AddRange(
                        sr.ReadLine().Split(' ').Where(elem => elem != "\r" && elem !="\n").Select(byte.Parse)
                    );
                }

                state.State = stateValues.ToArray();
            }

            return state;
        }
    }
}
