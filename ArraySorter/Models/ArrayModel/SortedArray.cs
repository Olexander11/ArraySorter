using System;
using System.Text;

namespace ArraySorter.Models.ArrayModel
{
    internal class SortedArray
    {
        public Guid Id { get; set; }
        public string SorterName { get; set; }
        public string IncommingArray { get; set; }
        public string SortingArray { get; set; }
        public string SortingStart { get; set; }
        public string SortingEnd{ get; set; }
    }
}
