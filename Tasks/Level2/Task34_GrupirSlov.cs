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
        List<string> words = new List<string>
        {
            "Яблоко", "Арбуз", "Банан", "Апельсин", "Брусника",
            "Вишня", "Виноград", "Авокадо", "Ягода", "Барбарис",
            "Груша", "Голубика"
        };

        Console.WriteLine("Исходный список слов:");
        Console.WriteLine(string.Join(", ", words));
        Console.WriteLine();

    
        var groupedWords = words
            .Select(w => w.ToLower())
            .OrderBy(w => w)
            .GroupBy(w => w[0])
            .OrderBy(g => g.Key);

        Console.WriteLine("--- Сгруппированные слова ---");
        foreach (var group in groupedWords)
        {
            string wordsInGroup = string.Join(", ", group);

            char letter = char.ToUpper(group.Key);

            Console.WriteLine($"{letter}: {wordsInGroup}");
        }
    }
}