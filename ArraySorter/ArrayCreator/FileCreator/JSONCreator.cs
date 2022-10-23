using ArraySorter.Controls;
using System;

namespace ArraySorter.ArrayCreator.FileCreator
{
    internal class JSONCreator : IFileArrayCreator, ISourceControl
    {
        private string path;

        public event EventHandler<EventArgs> ArrayComplit;

        public JSONCreator(string path)
        {
            this.path = path;
        }   

        public void Create()
        {          
            ArrayComplit?.Invoke(this, EventArgs.Empty);
        }

        public int[,] GetArray()
        {
            throw new NotImplementedException();
        }
    }
}
