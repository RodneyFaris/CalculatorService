using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorService
{

    public class Calculator : ICalculator
    {
        private readonly IDelimiterParser _delimiterParser;
        private readonly IDataParser _dataParser;
        private readonly IValidationService _validationService;
        private readonly IConstraints _constraints;

        public Calculator(IDelimiterParser delimiterParser, IDataParser dataParser,IValidationService validationService, IConstraints constraints)
        {
            _delimiterParser = delimiterParser ?? throw new ArgumentNullException(nameof(delimiterParser));
            _dataParser = dataParser ?? throw new ArgumentNullException(nameof(dataParser));
            _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
            _constraints = constraints ?? throw new ArgumentNullException(nameof(constraints));
        }

        public CalculatorResult CalculateSum(string input)
        {
            var delimiters = _delimiterParser.Parse(input);
            var values = _dataParser.Parse(input, delimiters);
            values = _constraints.ApplyConstraints(values);
            _validationService.Validate(values);
            var total = values.Sum();
            var formula = $"{string.Join("+", values)} = {total}";
            var result = new CalculatorResult()
            {
                Formula = formula,
                Value = total
            };
            return result;
        }

    }

    public class CalculatorResult
    {
        public string Formula { get; set; }
        public int Value { get; set; }
    }
}
