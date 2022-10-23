using CommonInterface;
using System;


namespace BubbleMethod
{
    public class Sorter : ISorter
    {
        private int speed = 1;
        public int Speed { get => speed;
            set 
            {
                lock (speedLock)
                {
                    if (value <= 1)
                        speed = 1;
                    else if (value >= 60 * 1000)
                        speed = 60 * 1000;
                    else
                        speed = value;
                }
            } 
        }

        private string sorterName = "Bubble Method";
        public string SorterName { get => sorterName; }

        private List<(int, int, int)> sortList = new List<(int, int, int)>();
        public List<(int, int, int)> SortList { get => sortList; set => sortList = value; }

        public event EventHandler ComparingElementsEvent;
        public event EventHandler ChangingElementsEvent;

        public void Sort()
        {
            if (SortList.Any())
            {
                (int, int, int) temp;
                for (int j = 0; j <= SortList.Count - 2; j++)
                {
                    for (int i = 0; i <= SortList.Count - 2; i++)
                    {
                        (int, int) first = (SortList[i].Item1, SortList[i].Item2);
                        (int, int) second = (SortList[i+1].Item1, SortList[i+1].Item2);
                        ComparingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                        WaitSomeTieme();
                        if (SortList[i].Item3 > SortList[i + 1].Item3)
                        {
                            ChangingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                            WaitSomeTieme();
                            temp = SortList[i + 1];
                            SortList[i + 1] = SortList[i];
                            SortList[i] = temp;
                        } 
                    }
                }
            }
        }

        private readonly object speedLock = new object();
        private void WaitSomeTieme()
        {
            lock (speedLock)
            {
                Thread.Sleep(Speed);
            }
        }
    }
}