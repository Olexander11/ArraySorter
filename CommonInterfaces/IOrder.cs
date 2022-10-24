using System.Collections.Generic;

namespace CommonInterfaces
{
    public interface IOrder
    {
        string OrderName { get; }
        (int, int) ArraySize { get; set; }

        IEnumerable<(int, int)> GetNumerator();
    }
}
