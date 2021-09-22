using FaleMais.Models;
using System.Collections.Generic;
using System.Linq;

namespace FaleMais.Services
{
    public class CallService
    {
        public IEnumerable<Plan> Plans = new List<Plan>()
        {

            new Plan
            {
                 Name = "Nenhum",
                 Discount = 0,
                 PlanType = PlanType.Nenhum
            },
            new Plan
            {
                 Name = "FaleMais30",
                 Discount = 30,
                 PlanType = PlanType.FaleMais30
            },
               new Plan
            {
                Name = "FaleMais60",
                 Discount = 60,
                 PlanType = PlanType.FaleMais60
            },
                  new Plan
            {
                Name = "FaleMais120",
                 Discount = 120,
                 PlanType = PlanType.FaleMais120
            }
        };

        public IEnumerable<Table> Tables = new List<Table>() {
            new Table
            {
                Origin = AreaCodes.DDD011,
                Destiny = AreaCodes.DDD016,
                Value = 1.90
            },
             new Table
            {
                Origin = AreaCodes.DDD016,
                Destiny = AreaCodes.DDD011,
                Value = 2.90
            },
              new Table
            {
                Origin = AreaCodes.DDD011,
                Destiny = AreaCodes.DDD017,
                Value = 1.70
            },
               new Table
            {
                Origin = AreaCodes.DDD017,
                Destiny = AreaCodes.DDD011,
                Value = 2.70
            },
                new Table
            {
                Origin = AreaCodes.DDD011,
                Destiny = AreaCodes.DDD018,
                Value = 0.90
            },
                 new Table
            {
                Origin = AreaCodes.DDD018,
                Destiny = AreaCodes.DDD011,
                Value = 1.90
            }
        };


        private Table GetTable(AreaCodes origin, AreaCodes destiny)
            => Tables.FirstOrDefault(x => x.Origin == origin && x.Destiny == destiny);

        private Plan GetPlan(PlanType type)
            => Plans.FirstOrDefault(x => x.PlanType == type);


        public Result CalculateCall(AreaCodes origin, AreaCodes destiny, PlanType type, double minutes)
        {
            Table table = GetTable(origin, destiny);
            Plan plan = GetPlan(type);
            double withoutPlan;
            double withPlan;
            if (plan.PlanType == PlanType.Nenhum)
            {
                var totalValue = table.Value * minutes;
                withPlan = totalValue;
                if (withPlan <= 0)
                    withPlan = 0;

                withoutPlan = table.Value * minutes;
            }
            else
            {
                var restMinutes = (minutes - plan.Discount);
                var totalValue = table.Value * restMinutes;

                if (restMinutes > 0)
                    totalValue += 0.10 * totalValue;

                withPlan = totalValue;
                if (withPlan <= 0)
                    withPlan = 0;

                withoutPlan = table.Value * minutes;
            }

            return new Result(withPlan, withoutPlan);
        }
    }
}
