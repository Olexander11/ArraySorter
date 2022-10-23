using System;
using System.Collections.Generic;
namespace CommonInterface
{
    public interface ISorter
    {
        string SorterName { get; }

        IEnumerable<(int, int)> SortList { get; set; }

        int[][] Array { get; set; }


        event EventHandler ComparingElementsEvent;
        event EventHandler ChangingElementsEvent;

        void Sort();
    }
}
