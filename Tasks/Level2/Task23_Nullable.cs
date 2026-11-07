using System;
using CSharpPraktikum.Common;
using System.Collections.Generic;

namespace CSharpPraktikum.Tasks.Level2;


public class Task23_Nullable : ITask
{
    public string Title => "Nullable-типы, ??, ?.";
    public string Description => "продемонстрировать работу с nullable.";
    public string[] Requirements => new[]
    {
        "Метод nt? FindValue(string key) — возвращает null, если ключа нет.",
        "Использовать ?? для значения по умолчанию.",
        "Использовать ?. для безопасного доступа к свойству объекта, который может быть null.",
        "Использовать HasValue / Value с проверкой.",
        "Продемонстрировать на примере с найденным и ненайденным ключом."
    };

    public void Run()
    {
  
        var database = new Dictionary<string, int>
        {
            { "яблоко", 10 },
            { "банан", 20 }
        };

        Console.WriteLine("--- Тестируем FindValue и nullable ---");

     
        int? foundValue = FindValue(database, "яблоко");
        Console.WriteLine($"Ключ 'яблоко': {foundValue}"); 

    
        int? notFoundValue = FindValue(database, "апельсин");
        Console.WriteLine($"Ключ 'апельсин': {notFoundValue.HasValue}"); 

   
        int defaultValue = notFoundValue ?? 0;
        Console.WriteLine($"notFoundValue ?? 0 = {defaultValue}");

        Person? person1 = new Person { Name = "Иван" };
        Person? person2 = null;

        string? name1 = person1?.Name;
        string? name2 = person2?.Name;

        Console.WriteLine($"Имя person1: {name1 ?? "Неизвестно"}");
        Console.WriteLine($"Имя person2: {name2 ?? "Неизвестно"}");

        if (foundValue.HasValue)
        {
    
            Console.WriteLine($"Точное значение: {foundValue.Value}");
        }
    }

    
    private int? FindValue(Dictionary<string, int> db, string key)
    {
        if (db.TryGetValue(key, out int result))
        {
            return result;
        }
        return null;
    }
}


public class Person
{
    public string? Name { get; set; }
}