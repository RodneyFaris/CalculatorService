using System.Collections.Generic;

namespace CalculatorService
{
    public interface IValidationService
    {
        bool IsValid { get; }
        string Message { get; }
        void Validate(List<int> values);
    }
}