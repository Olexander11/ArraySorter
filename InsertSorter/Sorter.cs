using CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSorter
{
    public class Sorter : ISorter
    {

        private string sorterName = "Insert Method";
        public string SorterName { get => sorterName; }


        IEnumerable<(int, int)> sortList = new List<(int, int)>();

        private int[][] array = null;
        public int[][] Array { get => array; set => array = value; }
        public IEnumerable<(int, int)> SortList { get => sortList; set => sortList = value; }

        public event EventHandler ComparingElementsEvent;
        public event EventHandler ChangingElementsEvent;

        public void Sort()
        {
            if (SortList.Any())
            {
                int n = SortList.Count();
                (int, int)[] sortedArray = SortList.ToArray();
                int replaceItem = 0;
                for (int i = 0; i < n - 1; ++i)
                {
                    int current = Array[sortedArray[i].Item1][sortedArray[i].Item2];
                    for (int j = i + 1; j < n; j++)
                    {
                        int item = Array[sortedArray[j].Item1][sortedArray[j].Item2];
                        if (item < current)
                        {
                            current = item;
                            replaceItem = j;
                        }
                        (int, int) first = (sortedArray[i].Item1, sortedArray[i].Item2);
                        (int, int) second = (sortedArray[j].Item1, sortedArray[j].Item2);
                        ComparingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                    }

                    if (current < Array[sortedArray[i].Item1][sortedArray[i].Item2])
                    {
                        (int, int) first = (sortedArray[i].Item1, sortedArray[i].Item2);
                        (int, int) second = (sortedArray[replaceItem].Item1, sortedArray[replaceItem].Item2);
                        int tempElement = Array[sortedArray[i].Item1][sortedArray[i].Item2];
                        Array[sortedArray[i].Item1][sortedArray[i].Item2] = Array[sortedArray[replaceItem].Item1][sortedArray[replaceItem].Item2];
                        Array[sortedArray[replaceItem].Item1][sortedArray[replaceItem].Item2] = tempElement;
                        ChangingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                    }
                }
            }
        }
    }
}
