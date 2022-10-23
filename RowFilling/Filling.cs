using CommonInterface;

namespace RowFilling
{
    public class Filling : IOrder
    {
        private int rows = 1;
        private int columns = 1;    
        public (int, int) ArraySize { get => (rows, columns);
            set 
            {
                if (value.Item1 > 0)
                    rows = value.Item1;
                if (value.Item2 > 0)
                    columns = value.Item2;
            } 
        }

        public string OrderName => "Row filling";

        public List<(int, int)> GetNumerator()
        {
            List<(int, int)> result = new List<(int, int)>(); 
            for (int i = 1; i <= columns; i++)
            {
                for(int j = 1; j <= rows; j++)
                {
                    result.Add((i, j));
                }
            }
            return result;
        }
    }
}