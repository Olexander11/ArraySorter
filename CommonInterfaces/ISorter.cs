using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface ISorter
    {
        string SorterName { get; }

        event EventHandler<ArraySorterEventArgument> ComparingElementsEvent;
        event EventHandler<ArraySorterEventArgument> ChangingElementsEvent;

        void Sort(int[,] array, IOrder order);

    }
}
