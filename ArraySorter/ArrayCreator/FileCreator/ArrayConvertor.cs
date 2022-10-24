using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorter.ArrayCreator.FileCreator
{
    internal class ArrayConvertor
    {
        public static int[,] ArrayConvert(int[][] array)
        {
            int row = array.Length;
            int col = array[0].Length;
            if (row > 0 && col > 0)
            {
                int[,] result = new int[row, col];

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        result[i, j] = array[i][j];
                    }
                }
                return result;
            }
            return null;
        }
    }
}
