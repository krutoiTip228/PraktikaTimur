using System;
using System.Diagnostics;
using System.Text;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task17_Concat : ITask
{
    private const int Count = 10_000;

    public string Title => "`StringBuilder` vs конкатенация (замер)";
    public string Description => "сравнить производительность конкатенации через `+` и `StringBuilder`";
    public string[] Requirements => new[]
    {
        "Собрать строку из 10 000 (или 100 000) чисел двумя способами.",
        "Замерить время каждого через `Stopwatch`",
        "Вывести оба времени и разницу.",
        "Объяснить в комментарии, почему `StringBuilder` быстрее. "
    };

    public void Run()
    {
        Console.WriteLine($"Склеиваем строку из {Count} чисел...\n");

        string concatResult = "";
        long concatMs = Measure(() => concatResult = BuildWithConcat());
        Console.WriteLine($"Конкатенация (+): {concatMs} мс");

        string builderResult = "";
        long builderMs = Measure(() => builderResult = BuildWithStringBuilder());
        Console.WriteLine($"StringBuilder:    {builderMs} мс");

        Console.WriteLine($"\nРазница во времени: {concatMs - builderMs} мс");
        Console.WriteLine($"Результаты равны: {concatResult == builderResult}");

        // Почему StringBuilder быстрее:
        // Строки в C# неизменяемы. Каждый "+" создаёт НОВУЮ строку и копирует в неё всё
        // содержимое старой, а старая уходит сборщику мусора. На N итераций получается
        // порядка N² копирований символов.
        // StringBuilder хранит изменяемый буфер символов и просто дописывает в него,
        // увеличивая буфер лишь изредка (с запасом), поэтому работает за линейное время.
    }

    private static string BuildWithConcat()
    {
        string result = "";
        for (int i = 0; i < Count; i++)
            result += i;
        return result;
    }

    private static string BuildWithStringBuilder()
    {
        var builder = new StringBuilder();
        for (int i = 0; i < Count; i++)
            builder.Append(i);
        return builder.ToString();
    }

    private static long Measure(Action action)
    {
        var stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
