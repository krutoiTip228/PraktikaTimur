using System;
using CSharpPraktikum.Common;
using System.Linq;
namespace CSharpPraktikum.Tasks.Level1;

public class Task13_Dictionary : ITask
{

    public string Title => "13.Счётчик вхождений слов в тексте (Dictionary)";
    public string Description => "посчитать, сколько раз каждое слово встречается в тексте.";
    public string[] Requirements => new[] {

    "Использовать Dictionary<string, int>.",
    "Разбить текст на слова (по пробелам и знакам пунктуации).",
    "Привести слова к нижнему регистру.",
    "Иначе — само число.",
    "Вывести пары «слово → количество», отсортированные по убыванию количества."
    };

    public void Run()
    {
        Console.WriteLine("Введите своё предложение(или нажмите Enter для тестового текста)");
        string? vvod = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(vvod))
        {

            vvod = "Привет, мир. Привет. Пока, мир.";
            Console.WriteLine($"Используется тестовый текст: \"{vvod}\"");

        }

        string cleanText = vvod
            .Replace(".", " ")
             .Replace(",", " ")
              .Replace("!", " ")
               .Replace("?", " ")
                .Replace(":", " ")
                 .Replace(";", " ")
                  .Replace("-", " ");


        string[] words = cleanText.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);


        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        foreach (string word in words)
        {

            string lowerWord = word.ToLower();

            if (wordCounts.ContainsKey(lowerWord))
            {

                wordCounts[lowerWord]++;

            }
            else
            {
                wordCounts.Add(lowerWord, 1);
            }

        }
        Console.WriteLine("\nРезультаты(слово -> количество):");
        Console.WriteLine("______________________________________________");



        var sortedWords = wordCounts.OrderByDescending(x => x.Value);


        foreach (var pair in sortedWords)
        {
            Console.WriteLine($"{pair.Key,-15} : {pair.Value} ");
        }
    }
}
