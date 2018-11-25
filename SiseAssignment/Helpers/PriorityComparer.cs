using System.Collections.Generic;

namespace SiseAssignment.Helpers
{
    public class PriorityComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x <= y) return -1;
            return 1;
        }
    }
}
