using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task05_MultiplicationTable : ITask
{
    private const int Size = 10;

    public string Title => "5.Таблица умножения 10*10";
    public string Description => "вывести таблицу умножения 10*10.";
    public string[] Requirements => new[]
    {
        "Использовать вложенные циклы for.",
        "Выровнять столбцы",
        "Заголовки строк/столбцов — не обязательны, но приветствуются."
    };

    public void Run()
    {
        // Заголовок столбцов
        Console.Write("     ");
        for (int col = 1; col <= Size; col++)
            Console.Write($"{col,4}");
        Console.WriteLine();
        Console.WriteLine(new string('-', 45));

        // Строки таблицы
        for (int row = 1; row <= Size; row++)
        {
            Console.Write($"{row,4} |");
            for (int col = 1; col <= Size; col++)
                Console.Write($"{row * col,4}");
            Console.WriteLine();
        }
    }
}
