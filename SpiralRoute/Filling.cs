using CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralRoute
{
    public class Filling : IOrder
    {
        private int rows = 1;
        private int columns = 1;
        public (int, int) ArraySize
        {
            get => (rows, columns);
            set
            {
                if (value.Item1 > 0)
                    rows = value.Item1;
                if (value.Item2 > 0)
                    columns = value.Item2;
            }
        }

        public string OrderName => "Spiral filling";
        public override string ToString()
        {
            return OrderName;
        }

        public IEnumerable<(int, int)> GetNumerator()
        {
            SchemeBuilder builder = new SchemeBuilder();
            builder.GreateSchema(rows, columns);
            foreach (var item in builder.GetMoves())
                yield return item;
        }
    }
}
