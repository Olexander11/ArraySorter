using CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSorter
{
    public class Sorter : ISorter
    {

        private string sorterName = "Bubble Method";
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
                (int, int)[] sortedArray = SortList.ToArray();
                for (int j = 0; j <= sortedArray.Length - 1; j++)
                {
                    for (int i = 0; i <= sortedArray.Length - 2; i++)
                    {
                        (int, int) first = (sortedArray[i].Item1, sortedArray[i].Item2);
                        (int, int) second = (sortedArray[j].Item1, sortedArray[j].Item2);
                        ComparingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));

                        if (Array[sortedArray[i].Item1][sortedArray[i].Item2] > Array[sortedArray[i + 1].Item1][sortedArray[i + 1].Item2])
                        {
                            ChangingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                            int tempElement = Array[sortedArray[i].Item1][sortedArray[i].Item2];
                            Array[sortedArray[i].Item1][sortedArray[i].Item2] = Array[sortedArray[i + 1].Item1][sortedArray[i + 1].Item2];
                            Array[sortedArray[i + 1].Item1][sortedArray[i + 1].Item2] = tempElement;
                            (int, int) temp = sortedArray[i];
                            sortedArray[i] = sortedArray[i + 1];
                            sortedArray[i + 1] = temp;
                        }
                    }
                }
            }
        }
    }
}
