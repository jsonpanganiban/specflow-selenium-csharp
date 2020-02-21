using System;
using System.ComponentModel;

namespace Jupiter.Framework.Utilities
{
    public static class StringHelper
    {
        public static String RemoveCurrency(this string value)
        {
            return value.Replace("$", string.Empty);
        }
    }
}