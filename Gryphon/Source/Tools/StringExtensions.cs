using System;
using System.Collections.Generic;
using System.Text;

namespace Gryphon.Tools
{
    public static class StringExtensions
    {
        public static string Truncate(this string str, int iLength)
        {
            if (str == null || iLength < 0)
            {
                return null;
            }
            else if (iLength == 0)
            {
                return string.Empty;
            }

            return str.Substring(iLength);
        }
    }

    public static class ExceptionExtensions
    {
        public static string Unroll(this Exception ex)
        {
            return string.Empty;
        }
    }
}
