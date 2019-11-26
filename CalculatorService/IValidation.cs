using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService
{
    public interface IValidation
    {
        bool IsValid { get; set; }
        string Message { get; }

        void Validate(List<int> values);
    }
}
