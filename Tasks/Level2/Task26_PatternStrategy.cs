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
        const decimal price = 1000m;
        Console.WriteLine($"Исходная цена: {price} руб.\n");

        PrintPrice("Обычный клиент", new NoDiscount(), price);
        PrintPrice("VIP клиент", new VipDiscount(), price);
        PrintPrice("С промокодом", new PromoDiscount(), price);
    }

    private static void PrintPrice(string label, IDiscountStrategy strategy, decimal price)
    {
        var calculator = new PriceCalculator(strategy);
        Console.WriteLine($"{label,-15}: {calculator.CalculateFinalPrice(price)} руб.");
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
    public decimal Apply(decimal price) => price * 0.90m; // скидка 10%
}

public class PromoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price * 0.80m; // скидка 20%
}

public class PriceCalculator
{
    private readonly IDiscountStrategy _strategy;

    public PriceCalculator(IDiscountStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal CalculateFinalPrice(decimal price) => _strategy.Apply(price);
}
