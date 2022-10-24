using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public class ArraySorterEventArgument : EventArgs
    {
        public ArraySorterEventArgument((int, int) first, (int, int) second)
        {
            FirstElement = first;
            SecondElement = second;
        }
        public (int, int) FirstElement { get;private set; }
        public (int, int) SecondElement { get; private set; }
    }
}
