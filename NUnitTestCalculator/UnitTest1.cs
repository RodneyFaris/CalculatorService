using System;
using System.Collections.Generic;
using NUnit.Framework;
using CalculatorService;

namespace NUnitTestCalculator
{
    [TestFixture]
    public class Tests
    {
        private DelimiterParser _delimiterParser;
        DataParser _dataParser;
        IValidationService _validationService;
        private IConstraints _constraints;
        Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _delimiterParser = new DelimiterParser();
            _dataParser = new DataParser();
            IValidation lengthValidation = new LengthValidation();
            var validations = new List<IValidation>
            {
                lengthValidation
            };
            IConstraint maxNumberConstraint = new MaxNumberConstraint();
            var constraints = new List<IConstraint>
            {
                maxNumberConstraint
            };

            _validationService = new ValidationService(validations);
            _constraints = new Constraints(constraints);
            _calculator = new Calculator(_delimiterParser, _dataParser, _validationService, _constraints);
        }

        [Test]
        public void ValidDataTest()
        {
            const string input = "10,50";

            var result = _calculator.CalculateSum(input);

            Assert.IsTrue(result.Value == 60);
        }
        [Test]
        public void EmptyDataTest()
        {
            const string input = ",50";

            var result = _calculator.CalculateSum(input);

            Assert.IsTrue(result.Value == 50);

        }
        [Test]
        public void NonNumericDataTest()
        {
            const string input = "ab,ff";

            var result = _calculator.CalculateSum(input);
            Assert.IsTrue(result.Value == 0);
        }
        [Test]
        public void LengthDataTest()
        {
            const string input = "1,2,3,4,5,6,7,8,9,10,11,12";

            var result = _calculator.CalculateSum(input);
            Assert.IsTrue(result.Value == 78);
        }

        [Test]
        public void MultipleDelimiterTest()
        {
            const string input = "1\n2,3\n4,5\n6,7,8,9,10,11,12";
            var result = _calculator.CalculateSum(input);
            Assert.IsTrue(result.Value == 78);
        }

        [Test]
        public void NegativeNumbersTest()
        {
            const string input = "1\n2,3\n4,-5\n6,-7,8,9,-10,11,12";
            var result = _calculator.CalculateSum(input);
            Assert.IsTrue(result.Value != 78);
        }

        [Test]
        public void MaxValueTest()
        {
            const string input = "1,2,3,4,5,6,7,8,9,1001,10,11,12";
            var result = _calculator.CalculateSum(input);
            Assert.IsTrue(result.Value == 78);
        }

        [Test]
        public void SingleCustomDelimiterTest()
        {
            const string input = "//,\n2,ff,100";
            var result = _calculator.CalculateSum(input);
            Assert.IsTrue(result.Value == 102);
        }

        [Test]
        public void SingleCustomDelimiterAnyLengthTest()
        {
            const string input = "//[***]\n11***22***33";
            var result = _calculator.CalculateSum(input);
            Assert.IsTrue(result.Value == 66);
        }
        [Test]
        public void MultipleCustomDelimiterAnyLengthTest()
        {
            const string input = "//[*][!!][r9r]\n11r9r22*hh*33!!44";
            var result = _calculator.CalculateSum(input);
            Assert.IsTrue(result.Value == 110);
        }
    }
}