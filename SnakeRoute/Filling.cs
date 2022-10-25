using CommonInterfaces;
using System.Collections.Generic;

namespace SnakeRoute
{
    public class Filling : IOrder
    {

        public string OrderName => "Snake filling";
        public override string ToString()
        {
            return OrderName;
        }

        public IEnumerable<(int, int)> GetNumerator(int rows, int columns)
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
