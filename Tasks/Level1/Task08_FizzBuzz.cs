using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task08_FizzBuzz : ITask
{

    public string Title => "8.FizzBuzz 1-100";
    public string Description => "вывести числа от 1 до 100 с заменами.";
    public string[] Requirements => new[] {

    "Кратно 3 → Fizz.",
    "Кратно 5 → Buzz.",
    "Кратно 15 → FizzBuzz.",
    "Иначе — само число.",
    "Порядок проверок: сначала 15, потом 3 и 5."
    };

    public void Run()
    {
        int i;
        for (i = 0; i < 101; i++)
        {
            if (i % 15 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }

    }
}