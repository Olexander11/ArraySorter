using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterfaces
{
    public interface IOrder
    {
        string OrderName { get; }
        (int, int) ArraySize { get; set; }

        IEnumerable<(int, int)> GetNumerator();
    }
}
