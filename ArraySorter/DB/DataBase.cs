using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorter.DB
{
    internal class DataBase
    {
        static DataBase instance;
        private string dbConnection = @"Data Source =.\SQLEXPRESS;Initial Catalog = SorterDB; Integrated Security = True";

        protected DataBase()
        {
        }

        public static DataBase Instance()
        {
            if (instance == null)
            {
                instance = new DataBase();
            }
            return instance;
        }

    }
}
