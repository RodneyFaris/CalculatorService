using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorService
{
    public class DataParser : IDataParser
    {
        public DataParser()
        {
        }

        public List<int> Parse(string input, string[] delimiters)
        {
            const string dataPattern = "(?<=\\n)(.*)";

            string dataSection = input;

            var inputUnescaped = Regex.Unescape(input);
            if (input.StartsWith("//"))
            {
                var data = Regex.Match(inputUnescaped, dataPattern);
                dataSection = data?.Value;
            }

            var values = dataSection.Split(delimiters, StringSplitOptions.None);
            var results = new List<int>();
            foreach (var item in values)
            {
                results.Add(int.TryParse(item, out int result) ? result : 0);
            }

            return results;
        }
    }
}
