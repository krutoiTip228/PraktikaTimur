using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task02_PerPrimTip : ITask
{
    public string Title => "2.Переменные примитивных типов";
    public string Description => "объявить переменные всех примитивных типов и вывести их значения и типы.";
    public string[] Requirements => new[]
    {
        "Объявить минимум: int, long, double, float, decimal, bool, char, string.",
        "Для каждой переменной вывести значение и GetType().Name.",
        "decimal — с суффиксом m, float — с f."
    };

    public void Run()
    {
        Console.WriteLine("Все переменные и их типы\n");

        int integer = 20;
        long bigNumber = 3_000_000_000L;
        double doubleValue = 4.15649;
        float floatValue = 43f;
        decimal decimalValue = 99.9m;
        bool flag = true;
        char symbol = 'A';
        string text = "Пример строки";

        PrintVariable(1, integer);
        PrintVariable(2, bigNumber);
        PrintVariable(3, doubleValue);
        PrintVariable(4, floatValue);
        PrintVariable(5, decimalValue);
        PrintVariable(6, flag);
        PrintVariable(7, symbol);
        PrintVariable(8, text);
    }

    private static void PrintVariable(int number, object value)
    {
        Console.WriteLine($"{number}. {value} ({value.GetType().Name})");
    }
}
