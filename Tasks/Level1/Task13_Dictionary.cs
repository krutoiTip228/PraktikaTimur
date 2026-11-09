using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task13_Dictionary : ITask
{
    private const string SampleText = "Привет, мир. Привет. Пока, мир.";
    private static readonly char[] Separators = { ' ', '.', ',', '!', '?', ':', ';', '-' };

    public string Title => "13.Счётчик вхождений слов в тексте (Dictionary)";
    public string Description => "посчитать, сколько раз каждое слово встречается в тексте.";
    public string[] Requirements => new[]
    {
        "Использовать Dictionary<string, int>.",
        "Разбить текст на слова (по пробелам и знакам пунктуации).",
        "Привести слова к нижнему регистру.",
        "Вывести пары «слово → количество», отсортированные по убыванию количества."
    };

    public void Run()
    {
        Console.WriteLine("Введите текст (или нажмите Enter для тестового текста)");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            input = SampleText;
            Console.WriteLine($"Используется тестовый текст: \"{input}\"");
        }

        Dictionary<string, int> counts = CountWords(input);

        Console.WriteLine("\nРезультаты (слово -> количество):");
        Console.WriteLine(new string('_', 30));

        foreach (var pair in counts.OrderByDescending(p => p.Value))
            Console.WriteLine($"{pair.Key,-15} : {pair.Value}");
    }

    private static Dictionary<string, int> CountWords(string text)
    {
        var counts = new Dictionary<string, int>();
        string[] words = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            string key = word.ToLower();
            counts[key] = counts.GetValueOrDefault(key) + 1;
        }

        return counts;
    }
}
