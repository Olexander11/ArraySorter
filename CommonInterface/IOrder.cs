
using System;
using System.Collections.Generic;
namespace CommonInterface
{
    public interface IOrder
    {
        string OrderName { get; }
        (int, int) ArraySize { get; set; }

        List<(int, int)> GetNumerator();
    }
}