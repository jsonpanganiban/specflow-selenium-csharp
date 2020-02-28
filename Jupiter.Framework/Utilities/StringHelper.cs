using System;
using System.Text.RegularExpressions;

namespace Jupiter.Framework.Utilities
{
    public static class StringHelper
    {
        public static String RemoveCurrency(this string value)
        {
            return Regex.Replace(value, @"[^\d.,]", string.Empty);
        }
    }
}