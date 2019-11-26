using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CalculatorService
{
    public class NegativeNumberValidation : IValidation
    {
        private int[] _negativeValues;

        public string Message
        {
            get => $"Negative numbers were provided: {string.Join(',', _negativeValues)}";
        }

        public bool IsValid { get; set; }

        public void Validate(List<int> values)
        {
            _negativeValues = values.Where(v => v < 0).ToArray();
            IsValid = _negativeValues.Length == 0;
            if (!IsValid)
            {
                throw new ValidationException(Message);
            }
        }
    }
}