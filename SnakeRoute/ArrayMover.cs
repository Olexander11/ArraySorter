using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeRoute
{
    internal class ArrayMover
    {
        private (int, int) lastPoint = (0, 0);
        internal IEnumerable<(int, int)> Move(ComandType comandType, int steps)
        {
            if (lastPoint.Item1 == 0 && lastPoint.Item2 == 0)
            {
                lastPoint.Item1 = 1;
                lastPoint.Item2 = 1;
                yield return lastPoint;
            }

            (int, int) currentPoint = lastPoint;
            switch (comandType)
            {
                case ComandType.right:
                    for (int i = lastPoint.Item1 + 1; i <= lastPoint.Item1 + steps; i++)
                    {
                        currentPoint.Item1 += i;
                        yield return currentPoint;
                    }
                    lastPoint = currentPoint;
                    break;
                case ComandType.down:
                    for (int i = lastPoint.Item2 + 1; i <= lastPoint.Item2 + steps; i++)
                    {
                        currentPoint.Item2 += i;
                        yield return currentPoint;
                    }
                    lastPoint = currentPoint;
                    break;
                case ComandType.left:
                    for (int i = lastPoint.Item1 + 1; i <= lastPoint.Item1 - steps; i--)
                    {
                        currentPoint.Item1 -= i;
                        yield return currentPoint;
                    }
                    lastPoint = currentPoint;
                    break;
                case ComandType.up:
                    for (int i = lastPoint.Item2 + 1; i <= lastPoint.Item2 - steps; i--)
                    {
                        currentPoint.Item2 -= i;
                        yield return currentPoint;
                    }
                    lastPoint = currentPoint;
                    break;
                case ComandType.left_down:
                    for (int i = lastPoint.Item1 + 1; i <= 1; i--)
                    {
                        currentPoint.Item2++;
                        currentPoint.Item1--;
                        yield return currentPoint;
                    }
                    lastPoint = currentPoint;
                    break;
                case ComandType.right_up:
                    for (int i = lastPoint.Item2 + 1; i <= 1; i--)
                    {
                        currentPoint.Item1++;
                        currentPoint.Item2--;
                        yield return currentPoint;
                    }
                    lastPoint = currentPoint;
                    break;
            }
        }
    }
}
