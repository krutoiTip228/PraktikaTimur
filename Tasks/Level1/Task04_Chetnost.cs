using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task04_Chetnost : ITask
{
    public string Title => "4.Чётность числа (два способа)";
    public string Description => "определить, чётное ли введённое число.";
    public string[] Requirements => new[]
    {
        "Способ 1: через % 2 == 0.",
        "Способ 2: через тернарный оператор ? :.",
        "Оба способа реализовать отдельными методами.",
        "Вывести результат обоих способов."
    };

    public void Run()
    {
        Console.WriteLine("Введите целое число, и мы проверим его на чётность двумя способами");

        if (!long.TryParse(Console.ReadLine(), out long number))
        {
            Console.WriteLine("Ошибка: Нужно ввести целое число");
            return;
        }

        Console.WriteLine($"Способ 1 (через %): число {number} — {(IsEvenByModulo(number) ? "чётное" : "нечётное")}");
        Console.WriteLine($"Способ 2 (тернарный оператор): число {number} — {CheckByTernary(number)}");
    }

    private static bool IsEvenByModulo(long number)
    {
        return number % 2 == 0;
    }

    private static string CheckByTernary(long number)
    {
        return number % 2 == 0 ? "чётное" : "нечётное";
    }
}
