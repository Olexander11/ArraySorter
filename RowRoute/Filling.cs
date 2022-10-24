using CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowRoute
{
    public class Filling : IOrder
    {
        private int rows = 1;
        private int columns = 1;
        public (int, int) ArraySize
        {
            get => (rows, columns);
            set
            {
                if (value.Item1 > 0)
                    rows = value.Item1;
                if (value.Item2 > 0)
                    columns = value.Item2;
            }
        }

        public string OrderName => "Row filling";
        public override string ToString()
        {
            return OrderName;
        }

        public IEnumerable<(int, int)> GetNumerator()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    yield return (i, j);
                }
            }
        }
    }
}
