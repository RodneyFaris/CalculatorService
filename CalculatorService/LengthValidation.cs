using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Text;

namespace CalculatorService
{
    public class LengthValidation : IValidation
    {
        private const int MaxLength = 2;
        private const int MinLength = 0;

        public  string Message
        {
            get =>  $"More than {MaxLength} numbers were provided."; 
        }

        public bool IsValid { get; set; }
        public void Validate(List<int> context)
        {
            IsValid = context.Count > MinLength;
            if (!IsValid)
            {
                throw new ValidationException(Message);
            }
            
        }
    }
}
