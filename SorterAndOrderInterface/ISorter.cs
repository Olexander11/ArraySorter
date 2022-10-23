namespace SorterAndOrderInterface
{
    public interface ISorter
    {
        int Speed { get; set; }
        string SorterName { get; }

        List<(int, int, int)> SortList { get; set; }


        event EventHandler ComparingElementsEvent;
        event EventHandler ChangingElementsEvent;

        void Sort();
    }
}