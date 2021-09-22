using FaleMais.Models;
using FaleMais.Services;
using System;

namespace FaleMais
{
    class Program
    {
        static void Main(string[] args)
        {
            var callService = new CallService();

            Console.WriteLine("Olá, escolha o plano");
            foreach (var item in callService.Plans)
            {
                Console.WriteLine($"{item.Name} - {(short)item.PlanType}");
            }
            var plan = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Escolha a Origem(DDD)");
            foreach (AreaCodes area in (AreaCodes[])Enum.GetValues(typeof(AreaCodes)))
            {
                Console.WriteLine($"{area} - {(int)area}");
            }

            var origin = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Escolha o Destino(DDD)");
            foreach (AreaCodes area in (AreaCodes[])Enum.GetValues(typeof(AreaCodes)))
            {
                Console.WriteLine($"{area} - {(int)area}");
            }

            var destiny = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Escolha a Duração em minutos: ");
            var minutes = Console.ReadLine();

            var result = callService.CalculateCall((AreaCodes)Convert.ToInt32(origin), (AreaCodes)Convert.ToInt32(destiny), (PlanType)Convert.ToInt32(plan), Convert.ToDouble(minutes));
            Console.WriteLine();
            Console.WriteLine($"Com plano: {result.WithPlanValue:0.00}");
            Console.WriteLine();
            Console.WriteLine($"Sem plano: {result.WithoutPlanValue:0.00}");
            Console.ReadKey();

        }
    }
}
