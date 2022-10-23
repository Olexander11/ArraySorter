using CommonInterface;

namespace InsertMethod
{
    public class Sorter : ISorter
    {
        private int speed = 1 ;
        public int Speed
        {
            get => speed;
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

        private string sorterName = "Insert Method";
        public string SorterName { get => sorterName; }


        private List<(int, int, int)> sortList = new List<(int, int, int)>();
        public List<(int, int, int)> SortList { get => sortList; set => sortList = value; }

        public event EventHandler ComparingElementsEvent;
        public event EventHandler ChangingElementsEvent;

        public void Sort()
        {
            if (SortList.Any())
            {
                int n = SortList.Count;
                for (int i = 1; i < n; ++i)
                {
                    var key = SortList[i];
                    int j = i - 1;

                    (int, int) first = (key.Item1, key.Item2);
                    (int, int) second = (SortList[j].Item1, SortList[j].Item2);
                    ComparingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                    WaitSomeTieme();
                    while (j >= 0 && SortList[j].Item3 > key.Item3)
                    {
                        first = (SortList[j + 1].Item1, SortList[j + 1].Item2);
                        second = (SortList[j].Item1, SortList[j].Item2);
                        ChangingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                        WaitSomeTieme();
                        SortList[j + 1] = SortList[j];
                        j = j - 1;
                        if (j >= 0)
                        {
                            second = (SortList[j].Item1, SortList[j].Item2);
                            ComparingElementsEvent?.Invoke(this, new ArraySorterEventArgument(first, second));
                            WaitSomeTieme();
                        }
                    }
                    SortList[j + 1] = key;
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