using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorService
{
    public class MaxNumberValidation : IValidation
    {
        private const int MaxValue = 1000;

        public string Message
        {
            get => $"Numbers greater than {MaxValue} are invalid.";
        }
        public  bool IsValid { get; set; }

        public void Validate(List<int> values)
        {
            IsValid = values.Any(v => v > MaxValue);
        }
    }
}
