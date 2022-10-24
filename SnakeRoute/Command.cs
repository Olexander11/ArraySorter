using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeRoute
{
    internal abstract class Command
    {
        public abstract IEnumerable<(int, int)> Execute();
    }

    enum ComandType
    {
        left,
        right,
        down,
        up,
        right_up,
        left_down,
        none
    }
}
