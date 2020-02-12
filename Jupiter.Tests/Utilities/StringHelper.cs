using System;
using System.Collections.Generic;
using System.Text;

namespace Jupiter.Tests.Utilities
{
    public static class StringHelper
    {
        public static String RemoveCurrency(string value)
        {
            return value.Replace("$", string.Empty);
        }
    }
}
