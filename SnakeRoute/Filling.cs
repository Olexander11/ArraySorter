using CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeRoute
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

        public string OrderName => "Snake filling";
        public override string ToString()
        {
            return OrderName;
        }

        public IEnumerable<(int, int)> GetNumerator()
        {
            for (int x = 0; x < rows + columns; x++)
            {
                if (x % 2 == 0)
                {
                    int i = x, j = 0;
                    while (i >= 0)
                    {
                        if (i < rows && j < columns)
                            yield return (i, j);

                        i--;
                        j++;
                    }
                }
                else
                {
                    int i = 0, j = x;
                    while (j >= 0)
                    {
                        if (i < rows && j < columns)
                            yield return (i, j);

                        i++;
                        j--;
                    }
                }
            }
        }
    }
}
