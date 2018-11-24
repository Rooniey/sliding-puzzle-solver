using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
