using ArraySorter.Controls;
using System;
using System.IO;

namespace ArraySorter.ArrayCreator.FileCreator
{
    internal class JSONCreator : IFileArrayCreator
    {
        private string path;

        public JSONCreator(string path)
        {
            this.path = path;
        }   

        int[,] IFileArrayCreator.Create()
        { 
            try
            {
                //using (StreamReader r = new StreamReader(path))
                //{

                //}
                //return ArrayConvertor.ArrayConvert();
            }
            catch
            {

            }
            return null;
        }
    }
}
