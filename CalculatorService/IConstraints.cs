using System.Collections.Generic;

namespace CalculatorService
{
    public interface IConstraints
    {
        List<int> ApplyConstraints(List<int> values);
    }
}