using System;
using System.Collections.Generic;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task23_Nullable : ITask
{
    private readonly Dictionary<string, int> _database = new()
    {
        ["яблоко"] = 10,
        ["банан"] = 20
    };

    public string Title => "Nullable-типы, ??, ?.";
    public string Description => "продемонстрировать работу с nullable.";
    public string[] Requirements => new[]
    {
        "Метод int? FindValue(string key) — возвращает null, если ключа нет.",
        "Использовать ?? для значения по умолчанию.",
        "Использовать ?. для безопасного доступа к свойству объекта, который может быть null.",
        "Использовать HasValue / Value с проверкой.",
        "Продемонстрировать на примере с найденным и ненайденным ключом."
    };

    public void Run()
    {
        Console.WriteLine("--- Тестируем FindValue и nullable ---");

        int? found = FindValue("яблоко");
        int? notFound = FindValue("апельсин");

        Console.WriteLine($"Ключ 'яблоко': {found}");
        Console.WriteLine($"Ключ 'апельсин' найден? {notFound.HasValue}");
        Console.WriteLine($"notFound ?? 0 = {notFound ?? 0}");

        if (found.HasValue)
            Console.WriteLine($"Точное значение: {found.Value}");

        Console.WriteLine("\n--- Оператор ?. ---");

        Person? withName = new Person { Name = "Иван" };
        Person? nobody = null;

        Console.WriteLine($"Имя первого человека: {withName?.Name ?? "Неизвестно"}");
        Console.WriteLine($"Имя второго человека: {nobody?.Name ?? "Неизвестно"}");
    }

    private int? FindValue(string key)
    {
        return _database.TryGetValue(key, out int value) ? value : null;
    }
}

public class Person
{
    public string? Name { get; set; }
}
