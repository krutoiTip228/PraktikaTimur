using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task01_HelloWorld : ITask
{
    public string Title => "1.Hello, World + текущая дата";
    public string Description => "Вывести приветствие и текущую дату";
    public string[] Requirements => new[]
    {
        "Использовать Console.WriteLine",
        "Дату получить через DateTime.Now, отформатировать как dd.MM.yyyy",
        "Вывести две строки: Приветствие и дату"
    };

    public void Run()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"Текущая дата: {DateTime.Now:dd.MM.yyyy}");
    }
}
