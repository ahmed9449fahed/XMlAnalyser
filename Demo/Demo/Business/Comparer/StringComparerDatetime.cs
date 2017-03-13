using System;
using System.Collections.Generic;
using System.Globalization;

namespace Demo.Business.Comparer
{
    internal class StringComparerDatetime : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            DateTime atime;
            DateTime btime;
            string[] formats =
            {
                "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "dd.MM.yyyy"
            };

            if (DateTime.TryParseExact(x, formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out atime) &&
                DateTime.TryParseExact(y, formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out btime))
                return atime.CompareTo(btime);
            return 0;
        }
    }
}
