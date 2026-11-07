using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task26_PatternStrategy : ITask
{
    public string Title => "Паттерн Стратегия (скидки)";
    public string Description => "Реализовать калькулятор скидок через паттерн Стратегия.";
    public string[] Requirements => new[]
    {
        "Интерфейс IDiscountStrategy с методом Apply(decimal price)",
        "Реализации: NoDiscount, VipDiscount (10%), PromoDiscount (20%)",
        "Класс PriceCalculator, принимающий стратегию в конструкторе",
        "Продемонстрировать расчёт цены с каждой стратегией"
    };

    public void Run()
    {
        decimal originalPrice = 1000m; 

        Console.WriteLine($"Исходная цена: {originalPrice} руб.\n");

      
        var calc1 = new PriceCalculator(new NoDiscount());
        Console.WriteLine($"Обычный клиент: {calc1.CalculateFinalPrice(originalPrice)} руб.");


        var calc2 = new PriceCalculator(new VipDiscount());
        Console.WriteLine($"VIP клиент:     {calc2.CalculateFinalPrice(originalPrice)} руб.");


        var calc3 = new PriceCalculator(new PromoDiscount());
        Console.WriteLine($"С промокодом:   {calc3.CalculateFinalPrice(originalPrice)} руб.");
    }
}


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
    public decimal Apply(decimal price) => price * 0.90m; 
}

public class PromoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price * 0.80m; 
}


public class PriceCalculator
{
    private readonly IDiscountStrategy _strategy;

   
    public PriceCalculator(IDiscountStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal CalculateFinalPrice(decimal price)
    {
     
        return _strategy.Apply(price);
    }
}