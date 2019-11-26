using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService
{
    public interface IDataParser
    {
        List<int> Parse(string input, string[] delimiters);
    }
}
