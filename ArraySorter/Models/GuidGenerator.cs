using System;

namespace ArraySorter.Models
{
    internal static class GuidGenerator
    {
        public static Guid Generate()
        {
            var today = DateTime.Now;

            var bytes = BitConverter.GetBytes(today.Ticks * 1000 + today.Millisecond);

            Array.Resize(ref bytes, 16);

            return new Guid(bytes);
        }
    }
}
