using System;

namespace ArraySorter.Controls
{
    internal interface ISourceControl
    {
        int[,] GetArray();

        event EventHandler<EventArgs> ArrayComplit;
    }
}
