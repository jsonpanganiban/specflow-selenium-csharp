using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.Utilities
{
    public static class TableHelpersExtension
    {
        public static Dictionary<string, string> ConvertToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}
