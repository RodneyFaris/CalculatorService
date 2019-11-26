using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService
{
    public interface ICalculator
    {
        CalculatorResult CalculateSum(string input);
    }
}
