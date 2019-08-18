using System;
using System.Linq;

namespace SGApp
{
    public static class CombinationPrinter
    {
        public static String PrintArray<T>(T[] possibleValues) =>
            '{' + string.Join('|', possibleValues.Select(x => x.ToString())) + '}';
    }
}
