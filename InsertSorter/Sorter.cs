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

        public override string ToString()
        {
            return SorterName;
        }

        public string SorterName => "Insert Method";


        public event EventHandler<ArraySorterEventArgument> ComparingElementsEvent;
        public event EventHandler<ArraySorterEventArgument> ChangingElementsEvent;

        public void Sort(int[,] array, IOrder order)
        {
            (int, int)[] sortedArray = order.GetNumerator(array.GetLength(0), array.GetLength(1)).ToArray();
            int n = sortedArray.Count();
            int replaceItem = 0;
            for (int i = 0; i < n - 1; ++i)
            {
                int current = array[sortedArray[i].Item1, sortedArray[i].Item2];
                replaceItem = i;
                for (int j = i + 1; j < n; j++)
                {
                    int item = array[sortedArray[j].Item1, sortedArray[j].Item2];

                    (int, int) first = sortedArray[replaceItem];
                    (int, int) second = sortedArray[j];
                    ComparingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));

                    if (item < current)
                    {
                        current = item;
                        replaceItem = j;
                    }
                }

                if (replaceItem != i)
                {
                    (int, int) first = sortedArray[i];
                    (int, int) second = sortedArray[replaceItem];
                    int tempElement = array[first.Item1, first.Item2];
                    array[first.Item1, first.Item2] = array[second.Item1, second.Item2];
                    array[second.Item1, second.Item2] = tempElement;
                    ChangingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                }
            }
        }
    }
}

