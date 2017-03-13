using System;
using System.Collections.Generic;

namespace Demo.Business.Comparer
{
    internal class StringComparerAlpha : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}
