using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task34_GrupirSlov : ITask
{
    public string Title => "LINQ: группировка слов по букве";
    public string Description => "Сгруппировать слова по первой букве через LINQ GroupBy.";
    public string[] Requirements => new[]
    {
        "Взять список слов (10+)",
        "Сгруппировать через LINQ GroupBy(w => w[0])",
        "Отсортировать группы по первой букве",
        "Внутри группы — отсортировать слова",
        "Вывести «Буква: слово1, слово2, ...»"
    };

    public void Run()
    {
        var words = new List<string>
        {
            "Яблоко", "Арбуз", "Банан", "Апельсин", "Брусника",
            "Вишня", "Виноград", "Авокадо", "Ягода", "Барбарис",
            "Груша", "Голубика"
        };

        Console.WriteLine("Исходный список слов:");
        Console.WriteLine(string.Join(", ", words));

        var groups = words
            .GroupBy(w => char.ToUpper(w[0]))
            .OrderBy(g => g.Key);

        Console.WriteLine("\n--- Сгруппированные слова ---");
        foreach (var group in groups)
        {
            // Слова внутри группы сортируем отдельно, регистр исходных слов сохраняется
            string line = string.Join(", ", group.OrderBy(w => w));
            Console.WriteLine($"{group.Key}: {line}");
        }
    }
}
