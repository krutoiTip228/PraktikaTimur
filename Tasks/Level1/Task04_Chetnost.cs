using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task04_Chetnost : ITask
{

    public string Title => "4.Чётность числа (два способа)";
    public string Description => "определить, чётное ли введённое число.";
    public string[] Requirements => new[] {

    "Способ 1: через % 2 == 0.",
    "Способ 2: через тернарный оператор ? :.",
    "Оба способа реализовать отдельными методами.",
    "Вывести результат обоих способов."
    };

    public void Run()
    {

        Console.WriteLine("Введите ваше число и проверим его на чётность двумя способами");
        double chisloChet1 = double.Parse(Console.ReadLine());
        
        if (chisloChet1 % 2 == 0)
        {

            Console.WriteLine($"Ваше число {chisloChet1} чётное. Использовался 1 способ");

        }
        else
        {

            Console.WriteLine($"Ваше число {chisloChet1} нечётное. Использовался 1 способ");

        }

        string result2sposob = (chisloChet1 % 2 == 0) ? "Чётное" : "Нечётное";
        Console.WriteLine($"Число {chisloChet1} - {result2sposob}. Использовался 2 способ");

    }
}