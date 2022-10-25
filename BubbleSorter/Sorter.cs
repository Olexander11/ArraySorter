using CommonInterfaces;
using System;
using System.Linq;

namespace BubbleSorter
{
    public class Sorter : ISorter
    {
        public override string ToString()
        {
            return SorterName;
        }

        public string SorterName => "Bubble Method";

        public event EventHandler<ArraySorterEventArgument> ComparingElementsEvent;
        public event EventHandler<ArraySorterEventArgument> ChangingElementsEvent;

        public void Sort(int[,] array, IOrder order)   // moving left->right)
        {
            (int, int)[] sortedArray = order.GetNumerator(array.GetLength(0), array.GetLength(1)).ToArray();
            for (int j = 1; j <= sortedArray.Length; j++)
            {
                for (int i = 0; i < sortedArray.Length - j; i++)
                {
                    (int, int) first = sortedArray[i];
                    (int, int) second = sortedArray[i + 1];
                    ComparingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));

                    if (array[first.Item1, first.Item2] > array[second.Item1, second.Item2])
                    {
                        ChangingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                        int tempElement = array[first.Item1, first.Item2];
                        array[first.Item1, first.Item2] = array[second.Item1, second.Item2];
                        array[second.Item1, second.Item2] = tempElement;
                    }
                }
            }
        }
    }
}
