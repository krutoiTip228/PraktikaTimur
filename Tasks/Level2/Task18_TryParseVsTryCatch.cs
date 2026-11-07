using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;


public class Task18_TryParseVsTryCatch : ITask
{
    public string Title => "TryParse vs try/catch";
    public string Description => "сравнить два способа обработки некорректного ввода числа.  ";
    public string[] Requirements => new[]
    {
        "Способ 1: `int.TryParse` — вернуть `bool` + значение через `out`.",
        "Способ 2: `int.Parse` внутри `try/catch` — ловить `FormatException`.",
        "Оба оформить отдельными методами.",
        "Продемонстрировать на корректном и некорректном вводе."
    };
    public void Run()
    {
        string[] testik = {"123", "abc", "47.7", "786978569785" };

        foreach (string vvod in testik)
        {
            Console.WriteLine($"Ввод: \"{vvod}\"");

            bool da1 = TryParseMethod(vvod, out int result1);
            Console.WriteLine($"  TryParse:  Успех = {da1}, Результат = {result1}");

   
            bool da2 = TryCatchMethod(vvod, out int result2);
            Console.WriteLine($"  try/catch: Успех = {da2}, Результат = {result2}");

            Console.WriteLine();
        }
    }


    private bool TryParseMethod(string testik, out int result)
    {

        return int.TryParse(testik, out result);
    }

    private bool TryCatchMethod(string vvod, out int result)
    {
        try
        {
      
            result = int.Parse(vvod);
            return true; 
        }
        catch (FormatException)
        {
           
            result = 0;
            return false;
        }
        catch (OverflowException)
        {
          
            result = 0;
            return false;
        }
    }
}