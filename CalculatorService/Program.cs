using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddTransient<IDelimiterParser, DelimiterParser>()
                .AddTransient<IDataParser, DataParser>()
                .AddTransient<IValidation, LengthValidation>()
                .AddTransient<IValidation, NegativeNumberValidation>()
                .AddTransient<IConstraint, MaxNumberConstraint>()
                .AddTransient<IConstraints, Constraints>()
                .AddTransient<IValidationService, ValidationService>()
                .AddSingleton<ICalculator, Calculator>();

            var serviceProvider = services.BuildServiceProvider();

            var validations = serviceProvider.GetServices<IValidation>();
            services.AddTransient<IValidationService>(s => new ValidationService(validations));

            var constraints = serviceProvider.GetServices<IConstraint>();
            services.AddTransient<IConstraints>(s => new Constraints(constraints));

            var calculator = serviceProvider.GetService<ICalculator>();

            Console.CancelKeyPress += ((s, a) =>
            {
                serviceProvider.Dispose();
                Console.Clear();
                a.Cancel = false;
                Environment.Exit(0);
            });

            do
            {
                try
                {
                    Console.Write("Enter formatted string of values: ");
                    var values =Console.ReadLine();
                    if (values != null)
                    {
                        var input = Regex.Unescape(values);
                        var result = calculator.CalculateSum(input);
                        Console.WriteLine(result.Formula);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            } while (true);
        }
    }
}
