namespace MiniExcelLibs.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

#if !(NETSTANDARD2_1 || NETCOREAPP2_1_OR_GREATER)
    internal static class IEnumerableHelper
    {
        public static bool StartsWith<T>(this IEnumerable<T> span, ICollection<T> value) where T : IEquatable<T>
        {
            return span.Take(value.Count).SequenceEqual(value);
        }
    }
#endif
}
