using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorService
{
    public class DelimiterParser : IDelimiterParser
    {
        public string[] Parse(string input)
        {
            const string delimiterSectionPattern = @"(?<=//)(.*)(?=\n)";
            const string delimiterItemPattern = @"(?<=\[)(.*?)(?=\])";
            const string multipleDelimiter = "//";

            var delimiters = new string[] { ",", "\n" };
            if (input.StartsWith(multipleDelimiter))
            {
                var delimiterSection = Regex.Match(input, delimiterSectionPattern);
                if (delimiterSection.Value.StartsWith("["))
                {
                    var dArray = Regex.Matches(delimiterSection.Value, delimiterItemPattern).Cast<Match>()
                        .Select(x => x.Value)?.ToArray();
                    var d = new string[delimiters.Length + dArray.Length];
                    delimiters.CopyTo(d, 0);
                    dArray.CopyTo(d, delimiters.Length);
                    return d;
                }
                else
                {
                    return delimiters.Concat(new string[] { delimiterSection.Value }).ToArray();
                }
            }

            return delimiters;
        }
    }
}
