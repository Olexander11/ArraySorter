using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorter.Models.ArrayModel
{
    internal class SortedArrayContext : DbContext
    {        public SortedArrayContext()
     : base("DbConnection")
        { }

        public DbSet<SortedArray> SortedArrays { get; set; }
    }
}
