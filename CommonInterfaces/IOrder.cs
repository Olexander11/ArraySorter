using System.Collections.Generic;

namespace CommonInterfaces
{
    public interface IOrder
    {
        string OrderName { get; }

        IEnumerable<(int, int)> GetNumerator(int rows, int columns);
    }
}
