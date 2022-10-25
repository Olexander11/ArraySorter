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

        public string OrderName => "Spiral filling";
        public override string ToString()
        {
            return OrderName;
        }

        public IEnumerable<(int, int)> GetNumerator(int rows, int columns)
        {
            int top = 0, bottom = rows - 1, left = 0, right = columns - 1;
            int dir = 1;
            while (top <= bottom && left <= right)
            {

                if (dir == 1)
                {
                    for (int i = left; i <= right; ++i)
                    {
                        yield return (top, i);
                    }
                    ++top;
                    dir = 2;
                }
                else if (dir == 2)
                {
                    for (int i = top; i <= bottom; ++i)
                    {
                        yield return (i, right);

                    }
                    --right;
                    dir = 3;
                }
                else if (dir == 3)
                {
                    for (int i = right; i >= left; --i)
                    {
                        yield return (bottom, i);
                    }
                    --bottom;
                    dir = 4;
                }
                else if (dir == 4)
                {
                    for (int i = bottom; i >= top; --i)
                    {
                        yield return (i, left);
                    }
                    ++left;
                    dir = 1;
                }
            }
        }
    }
}
