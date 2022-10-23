namespace SorterAndOrderInterface
{
    public class ArraySorterEventArgument : EventArgs
    {
        public ArraySorterEventArgument((int, int) first, (int, int) second)
        {
            firstElement = first;
            secondElement = second;
        }
        public (int, int) firstElement;
        public (int, int) secondElement;
    }
}
