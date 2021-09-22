using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMais.Models
{
    public struct Result
    {
        public Result(double withPlanValue, double withoutPlanValue)
        {
            WithPlanValue = withPlanValue;
            WithoutPlanValue = withoutPlanValue;
        }

        public double WithPlanValue { get; }
        public double WithoutPlanValue { get; }
    }
}
