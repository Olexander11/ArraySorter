using CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralRoute
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

        public string OrderName => "Spiral filling";
        public override string ToString()
        {
            return OrderName;
        }

        public IEnumerable<(int, int)> GetNumerator()
        {
            return GetNumerator2();
            //SchemeBuilder builder = new SchemeBuilder();
            //builder.GreateSchema(rows, columns);
            //foreach (var item in builder.GetMoves())
            //    yield return item;
        }

        public IEnumerable<(int, int)> GetNumerator2()
        {
            int circles = (int)Math.Ceiling(Math.Min(rows, columns) / 2.0);

            int count = 0;
            for (int c = 0; c < circles; c++)
            {
                // up row
                if (count < rows * columns)
                {
                    for (int i = c; i < columns - c - 1; i++)
                    {
                        count++;
                        yield return (c, i);
                    }
                }

                // right col
                if (count < rows * columns)
                {
                    for (int i = c; i < rows - c - 1; i++)
                    {
                        count++;
                        yield return (i, columns - c - 1);
                    }
                }

                // down row
                if (count < rows * columns)
                {
                    for (int i = columns - c - 1; i > c - 1; i--)
                    {
                        count++;
                        yield return (rows - c - 1, i);
                    }
                }

                // up col
                if (count < rows * columns)
                {
                    for (int i = rows - c - 1; i > c - 1; i--)
                    {
                        count++;
                        yield return (i, c);
                    }
                }
            }
        }
    }
}
