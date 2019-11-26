using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CalculatorService
{
    public class ValidationService : IValidationService
    {
        private readonly IEnumerable<IValidation> _validations;
        public ValidationService(IEnumerable<IValidation> validations)
        {
            _validations = validations;
        }

        public bool IsValid { get; set; }
        
        public string Message { get; set; }
        
        public void Validate()
        {
            IsValid = _validations.Any(v => !v.IsValid);

            if (!IsValid)
            {
                throw new ValidationException(Message);
            }
        }

        public void Validate(List<int> values)
        {
            foreach (var v in _validations)
            {
                v.Validate(values);
            }
        }
    }
}
