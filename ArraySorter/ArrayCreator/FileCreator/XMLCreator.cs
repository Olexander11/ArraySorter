using ArraySorter.Controls;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            FileStream str = new FileStream(path, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            int[,] returnValue = (int[,])binaryFormatter.Deserialize(str);
            str.Close();
            return returnValue;
        }

        public static void DeepSerialize<T>(T obj, string fileName)
        {
            FileStream str = new FileStream(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(str, obj);
            str.Close();
        }
        public static T DeepDeserialize<T>(string fileName)
        {
            FileStream str = new FileStream(fileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            T returnValue = (T)binaryFormatter.Deserialize(str);
            str.Close();
            return returnValue;
        }
    }
}
