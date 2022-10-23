using ArraySorter.Controls;
using System;

namespace ArraySorter.ArrayCreator.FileCreator
{
    internal class XMLCreator : IFileArrayCreator, ISourceControl
    {
        private string path;
        public event EventHandler<EventArgs> ArrayComplit;

        public XMLCreator(string path)
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
