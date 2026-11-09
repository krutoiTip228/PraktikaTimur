using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task20_SwapMaxIComparable : ITask
{
    public string Title => "Обобщения: Swap<T>,Max<T> с IComparable<T>";
    public string Description => "написать обобщённые методы.";
    public string[] Requirements => new[]
    {
        "Swap<T>(ref T a, ref T b) — меняет значения местами.",
        "Max<T>(T a, T b) where T : IComparable<T> — возвращает большее.",
        "Продемонстрировать на int, string, double.",
        "Swap — без ограничений, Max — с ограничением.  "
    };

    public void Run()
    {
        Console.WriteLine("Метод Swap");

        int a = 4, b = 5;
        Console.WriteLine($"int:    до {a} и {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"        после {a} и {b}");

        string s1 = "Цветок", s2 = "Земля";
        Console.WriteLine($"string: до {s1} и {s2}");
        Swap(ref s1, ref s2);
        Console.WriteLine($"        после {s1} и {s2}");

        double d1 = 1.5, d2 = 9.9;
        Console.WriteLine($"double: до {d1} и {d2}");
        Swap(ref d1, ref d2);
        Console.WriteLine($"        после {d1} и {d2}");

        Console.WriteLine("\nМетод Max");
        Console.WriteLine($"Max(15, 42) = {Max(15, 42)}");
        Console.WriteLine($"Max(3.14, 2.71) = {Max(3.14, 2.71)}");
        Console.WriteLine($"Max(\"Банан\", \"Арбуз\") = {Max("Банан", "Арбуз")}");
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        (first, second) = (second, first);
    }

    private static T Max<T>(T first, T second) where T : IComparable<T>
    {
        return first.CompareTo(second) > 0 ? first : second;
    }
}
