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
            firstElement = first;
            secondElement = second;
        }
        public (int, int) firstElement;
        public (int, int) secondElement;
    }
}
