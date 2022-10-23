using System;
using System.Text;

namespace ArraySorter.Models.ArrayModel
{
    internal class ArrayModelHelper
    {
        public static string ArrayToString(int[,] array)
        {
            StringBuilder sb = new StringBuilder();
            if (array != null && array.GetLength(0) > 0 && array.GetLength(1) > 0)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for(int j = 0; j < array.GetLength(1); j++)
                    {
                        sb.Append(array[i, j]); 
                        if (j != array.GetLength(1) - 1)
                            sb.Append(",");
                    }
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }
    }
}
