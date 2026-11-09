using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task07_Reverse : ITask
{
    public string Title => "7.Реверс строки без LINQ";
    public string Description => "перевернуть введённую строку.";
    public string[] Requirements => new[]
    {
        "Не использовать Array.Reverse и LINQ.",
        "Реализовать через цикл for от конца к началу (или через char[] и swap).",
        "Пустая строка и строка из одного символа — обрабатываются корректно."
    };

    public void Run()
    {
        Console.WriteLine("Введите строку для реверса");
        string input = Console.ReadLine() ?? string.Empty;

        Console.WriteLine($"Оригинал: \"{input}\"");
        Console.WriteLine($"Наоборот: \"{Reverse(input)}\"");
    }

    // Меняем местами символы с обоих концов (swap) — для "" и 1 символа цикл просто не выполняется
    private static string Reverse(string text)
    {
        char[] chars = text.ToCharArray();

        for (int left = 0, right = chars.Length - 1; left < right; left++, right--)
        {
            (chars[left], chars[right]) = (chars[right], chars[left]);
        }

        return new string(chars);
    }
}
