using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task18_TryParseVsTryCatch : ITask
{
    public string Title => "TryParse vs try/catch";
    public string Description => "сравнить два способа обработки некорректного ввода числа.  ";
    public string[] Requirements => new[]
    {
        "Способ 1: `int.TryParse` — вернуть `bool` + значение через `out`.",
        "Способ 2: `int.Parse` внутри `try/catch` — ловить `FormatException`.",
        "Оба оформить отдельными методами.",
        "Продемонстрировать на корректном и некорректном вводе."
    };

    public void Run()
    {
        string[] inputs = { "123", "abc", "47.7", "786978569785" };

        foreach (string input in inputs)
        {
            Console.WriteLine($"Ввод: \"{input}\"");

            bool ok1 = ParseWithTryParse(input, out int value1);
            Console.WriteLine($"  TryParse:  Успех = {ok1}, Результат = {value1}");

            bool ok2 = ParseWithTryCatch(input, out int value2);
            Console.WriteLine($"  try/catch: Успех = {ok2}, Результат = {value2}\n");
        }
    }

    private static bool ParseWithTryParse(string input, out int result)
    {
        return int.TryParse(input, out result);
    }

    private static bool ParseWithTryCatch(string input, out int result)
    {
        try
        {
            result = int.Parse(input);
            return true;
        }
        catch (Exception ex) when (ex is FormatException or OverflowException)
        {
            result = 0;
            return false;
        }
    }
}
