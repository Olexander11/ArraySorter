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

        IEnumerable<(int, int)> SortList { get; set; }

        int[,] Array { get; set; }


        event EventHandler ComparingElementsEvent;
        event EventHandler ChangingElementsEvent;

        void Sort();
    }
}
