using ArraySorter.Controls;
using System;

namespace ArraySorter.ArrayCreator.FileCreator
{
    internal class XMLCreator : IFileArrayCreator
    {
        private string path;

        public XMLCreator(string path)
        {
            this.path = path;
        }   

        int[,] IFileArrayCreator.Create()
        {
            throw new NotImplementedException();
        }
    }
}
