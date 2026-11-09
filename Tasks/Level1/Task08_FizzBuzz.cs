using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task08_FizzBuzz : ITask
{
    public string Title => "8.FizzBuzz 1-100";
    public string Description => "вывести числа от 1 до 100 с заменами.";
    public string[] Requirements => new[]
    {
        "Кратно 3 → Fizz.",
        "Кратно 5 → Buzz.",
        "Кратно 15 → FizzBuzz.",
        "Иначе — само число.",
        "Порядок проверок: сначала 15, потом 3 и 5."
    };

    public void Run()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(GetFizzBuzz(i));
        }
    }

    private static string GetFizzBuzz(int n)
    {
        if (n % 15 == 0) return "FizzBuzz";
        if (n % 3 == 0) return "Fizz";
        if (n % 5 == 0) return "Buzz";
        return n.ToString();
    }
}
