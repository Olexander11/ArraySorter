using ArraySorter.Controls;
using Newtonsoft.Json;
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
                int[][] doubleArray = JsonConvert.DeserializeObject<int[][]>(File.ReadAllText(path));
                return ArrayConvertor.ArrayConvert(doubleArray);
            }
            catch
            {

            }
            return null;
        }
    }
}
