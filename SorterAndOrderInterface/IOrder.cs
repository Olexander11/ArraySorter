namespace SorterAndOrderInterface
{
    public interface IOrder
    {
        (int, int) ArraySize { get; set; }

        List<(int, int)> GetNumerator();
    }
}
