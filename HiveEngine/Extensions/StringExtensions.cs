using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HiveEngine.Extensions
{
    internal static class StringExtensions
    {
        public static IEnumerable<int> GetAllIndexes(this string source, string matchString)
        {
            matchString = Regex.Escape(matchString);
            return from Match match in Regex.Matches(source, matchString) select match.Index;
        }
    }
}
