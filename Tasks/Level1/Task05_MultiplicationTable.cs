using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task05_MultiplicationTable : ITask
{

    public string Title => "5.Таблица умножения 10*10";
    public string Description => "вывести таблицу умножения 10*10.";
    public string[] Requirements => new[] {

    "Использовать вложенные циклы for.",
    "Выровнять столбцы",
    "Заголовки строк/столбцов — не обязательны, но приветствуются."
    };

    public void Run()
    {
        Console.Write("     ");
        for (int j = 1; j <= 10; j++)
        {
            Console.Write($"{j,4}");
        }
        Console.WriteLine();


        Console.WriteLine(new string('-', 45));

        for (int i = 1; i <= 10; i++)
        {

            Console.Write($"{i,4} |");

            for (int j = 1; j <= 10; j++)
            {
                int result = i * j;

                Console.Write($"{result,4}");
            }

            Console.WriteLine();
        }
    }
}