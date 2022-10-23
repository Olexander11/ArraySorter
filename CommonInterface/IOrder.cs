
using System;
using System.Collections.Generic;
namespace CommonInterface
{
    public interface IOrder
    {
        string OrderName { get; }
        (int, int) ArraySize { get; set; }

        IEnumerable<(int, int)> GetNumerator();
    }
}