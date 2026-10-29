using System;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{

    public interface IDiscountStrategy
    {
        decimal Apply(decimal price);
    }


    public class NoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price;
    }

    public class VipDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.9m;
    }

    public class PromoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.8m; 
    }


    public class PriceCalculator
    {
        private IDiscountStrategy _strategy;


        public PriceCalculator(IDiscountStrategy strategy)
        {
            _strategy = strategy;
        }


        public void SetStrategy(IDiscountStrategy strategy)
        {
            _strategy = strategy;
        }


        public decimal Calculate(decimal basePrice)
        {
            return _strategy.Apply(basePrice);
        }
    }


    public class Task26_Strategy : ITask
    {
        public string Title => "Паттерн «Стратегия» (скидки)";
        public string Description => "Реализовать калькулятор скидок через паттерн «Стратегия».";

        public string[] Requirements => new[]
        {
            "Интерфейс IDiscountStrategy с методом Apply(decimal price).",
            "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount (20%).",
            "Класс PriceCalculator, принимающий стратегию в конструкторе.",
            "Продемонстрировать расчёт цены с каждой стратегией."
        };

        public void Run()
        {
            decimal basePrice = 1000m;
            Console.WriteLine($"Базовая цена: {basePrice} руб.\n");

            PriceCalculator calcNoDiscount = new PriceCalculator(new NoDiscount());
            Console.WriteLine($"Без скидки:      {calcNoDiscount.Calculate(basePrice):F2} руб.");

            PriceCalculator calcVip = new PriceCalculator(new VipDiscount());
            Console.WriteLine($"VIP (10%):       {calcVip.Calculate(basePrice):F2} руб.");

            PriceCalculator calcPromo = new PriceCalculator(new PromoDiscount());
            Console.WriteLine($"Промо (20%):     {calcPromo.Calculate(basePrice):F2} руб.");

            Console.WriteLine("\n--- Смена стратегии для одного объекта ---");
            calcNoDiscount.SetStrategy(new PromoDiscount());
            Console.WriteLine($"Цена после смены на Промо: {calcNoDiscount.Calculate(basePrice):F2} руб.");
        }
    }
}