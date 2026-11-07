using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;


public class Task20_SwapMaxIComparable : ITask
{
    public string Title => "Обобщения: Swap<T>,Max<T> с IComparable<T>";
    public string Description => "написать обобщённые методы.";
    public string[] Requirements => new[]
    {
        "Swap<T>(ref T a, ref T b) — меняет значения местами.",
        "Max<T>(T a, T b) where T : IComparable<T> — возвращает большее.",
        "Продемонстрировать на int, string, double.",
        "Swap — без ограничений, Max — с ограничением.  "
    };

    public void Run()
    {

        Console.WriteLine("\nМетод Swap");

        int a = 4; int b = 5;
        Console.WriteLine($"До замены: {a} и {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"После замены: {a} и {b}");

        string s1 = "Цветок"; string s2 = "Земля";
        Console.WriteLine($"До замены: {s1} и {s2}");
        Swap(ref s1, ref s2);
        Console.WriteLine($"После замены: {s1} и {s2}");

        Console.WriteLine("\nМетод Max");

        Console.WriteLine($"Max(15, 42) = {Max(15, 42)}");
        Console.WriteLine($"Max(3.14, 2.71) = {Max(3.14, 2.71)}");
        Console.WriteLine($"Max(\"Банан\", \"Арбуз\") = {Max("Банан", "Арбуз")}");

    }


    static void Swap<T>(ref T x, ref T y)
    {
        T zam = x;
        x = y;
        y = zam;
    }
    static T Max<T>(T x, T y) where T : IComparable<T>
    {
        if (x.CompareTo(y) > 0)
        {
            return x;
        }
        else
        {
            return y;
        }
    }
}