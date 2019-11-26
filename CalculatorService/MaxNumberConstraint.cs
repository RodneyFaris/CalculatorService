using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService
{
    public class MaxNumberConstraint : IConstraint
    {
        private const int MaxValue = 1000;
        public bool IsValid(int value)
        {
            return (value <= MaxValue);
        }
    }
}
