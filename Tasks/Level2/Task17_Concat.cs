using System;
using System.Diagnostics;
using System.Text;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;


public class Task17_Concat : ITask
{
    public string Title => "`StringBuilder` vs конкатенация (замер)";
    public string Description => "сравнить производительность конкатенации через `+` и `StringBuilder`";
    public string[] Requirements => new[]
    {
        "Собрать строку из 10 000 (или 100 000) чисел двумя способами.",
        "Замерить время каждого через `Stopwatch`",
        "Вывести оба времени и разницу.",
        "Объяснить в комментарии, почему `StringBuilder` быстрее. "
    };
    public void Run()
    {
        int count = 10000;
        Console.WriteLine($"Склеиваем строку из {count} чисел...\n");

       
        Stopwatch sw1 = Stopwatch.StartNew();
        string resultConcat = "";
        for (int i = 0; i < count; i++)
        {
            resultConcat += i.ToString();
        }
        sw1.Stop();
        Console.WriteLine($"Конкатенация (+): {sw1.ElapsedMilliseconds} мс");

       
        Stopwatch sw2 = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append(i); 
        }
        string resultBuilder = sb.ToString();
        sw2.Stop();
        Console.WriteLine($"StringBuilder:    {sw2.ElapsedMilliseconds} мс");

       
        Console.WriteLine($"\nРазница во времени: {sw1.ElapsedMilliseconds - sw2.ElapsedMilliseconds} мс");
        Console.WriteLine($"Результаты равны: {resultConcat == resultBuilder}");

        // Объяснение:
        // При использовании "+" в цикле каждый раз выделяется НОВАЯ память под новую строку, 
        // а старая удаляется сборщиком мусора. На 10000 итераций это вызывает огромную нагрузку.
        // StringBuilder держит в памяти изменяемый массив символов и просто дописывает в него,
        // выделяя память только тогда, когда массив заполнен (он увеличивается в 2 раза).
    }
}
