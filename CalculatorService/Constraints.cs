using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorService
{
    public class Constraints : IConstraints
    {
        private readonly IEnumerable<IConstraint> _constraints;
        public Constraints(IEnumerable<IConstraint> constraints)
        {
            _constraints = constraints;
        }

        public List<int> ApplyConstraints(List<int> values)
        {
            var list = new List<int>();
            foreach (var v in values)
            {
                if (_constraints.Any(c => c.IsValid(v)))
                {
                    list.Add(v);
                }
            }

            return list;
        }
    }
}
