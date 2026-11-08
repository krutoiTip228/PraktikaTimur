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
        string filePath = "test_idisposable.txt";
        Console.WriteLine("Способ 1: Блок using");
        using (FileWriter writer = new FileWriter(filePath))
        {
            writer.WriteLine("Первая строка");
            writer.WriteLine("Вторая строка");
    
        }
        Console.WriteLine("Файл успешно записан и закрыт (блок using).");

        Console.WriteLine("\nСпособ 2: Декларация using (using var)");
        using var writer2 = new FileWriter("test_idisposable_2.txt");
        writer2.WriteLine("Строка из using-декларации");
        Console.WriteLine("Файлы созданы. Проверьте папку bin/Debug/netX.X/");
        Console.WriteLine("Если попытаться записать в закрытый файл, будет ошибка.");
    }
}
public class FileWriter : IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed = false;

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
        if (!_disposed)
        {
            _writer.Dispose();
            _disposed = true;
            Console.WriteLine("[FileWriter] Файл закрыт.");
        }
    }
}