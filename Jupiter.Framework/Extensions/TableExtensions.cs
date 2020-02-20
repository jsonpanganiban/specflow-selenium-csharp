using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Jupiter.Framework.Extensions
{
    public static class TableExtensions
    {
        public static Dictionary<string, string> ConvertToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static List<T> GetFirstColumnValues<T>(this Table table)
        {
            return table.Rows.Select(row => Convert.ChangeType(row[0], typeof(T))).Cast<T>().ToList();
        }
    }
}
