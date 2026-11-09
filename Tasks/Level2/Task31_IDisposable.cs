using System;
using System.IO;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task31_IDisposable : ITask
{
    public string Title => "IDisposable + using";
    public string Description => "Реализовать IDisposable для класса, работающего с файлом.";
    public string[] Requirements => new[]
    {
        "Класс FileWriter с полем StreamWriter",
        "Реализовать Dispose() (закрыть StreamWriter)",
        "Продемонстрировать использование через using",
        "Дополнительно: продемонстрировать using-декларацию (C# 8+, using var)"
    };

    public void Run()
    {
        Console.WriteLine("Способ 1: блок using");
        using (var writer = new FileWriter("test_idisposable.txt"))
        {
            writer.WriteLine("Первая строка");
            writer.WriteLine("Вторая строка");
        } // Dispose вызывается здесь
        Console.WriteLine("Файл записан и закрыт.");

        Console.WriteLine("\nСпособ 2: using-декларация (using var)");
        using var writer2 = new FileWriter("test_idisposable_2.txt");
        writer2.WriteLine("Строка из using-декларации");
        Console.WriteLine("Файлы лежат рядом с исполняемым файлом (например, bin/Debug/netX.X/).");
        Console.WriteLine("writer2 закроется автоматически при выходе из метода Run.");
    }
}

public class FileWriter : IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed;

    public FileWriter(string path)
    {
        _writer = new StreamWriter(path);
    }

    public void WriteLine(string text)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(FileWriter));

        _writer.WriteLine(text);
    }

    public void Dispose()
    {
        if (_disposed) return;

        _writer.Dispose();
        _disposed = true;
        Console.WriteLine("[FileWriter] Файл закрыт.");
    }
}
