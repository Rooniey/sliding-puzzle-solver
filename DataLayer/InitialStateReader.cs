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
            using (StreamReader sr = new StreamReader(path))
            {
                var dimensions = sr.ReadLine().Split(' ', '\r', '\n');
                byte x = byte.Parse(dimensions[0]);
                byte y = byte.Parse(dimensions[1]);

                var stateValues = new List<byte>();

                for (int i = 0; i < x; i++)
                {
                    stateValues.AddRange(
                        sr.ReadLine().Split(' ').Where(elem => elem != "\r" && elem !="\n").Select(byte.Parse)
                    );
                }

                return new PuzzleState(x, y, stateValues.ToArray());
            }
        }
    }
}
