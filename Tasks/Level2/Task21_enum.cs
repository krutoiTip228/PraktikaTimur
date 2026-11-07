using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;


public class Task21_enum : ITask
{
    public string Title => "enum дни недели";
    public string Description => "описать дни недели через enum и определить тип дня.";
    public string[] Requirements => new[]
    {
        "enum DayOfWeek { Monday, ..., Sunday }.",
        "Метод IsWeekend(DayOfWeek day) — true для субботы и воскресенья.",
        "Метод GetRussianName(DayOfWeek day) — возвращает название на русском.",
        "Продемонстрировать на всех 7 днях."
    };
    public void Run()
    {
        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            string russkiiNAme = GetRussianName(day);
            bool isWeekend = IsWeekend(day);

            string dayType = isWeekend ? "Выходной" : "Рабочий";
            Console.WriteLine($"{day,-10} ({russkiiNAme,-12}) -> {dayType}");
        }
    }

    private bool IsWeekend(DayOfWeek day)
    {
        return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
    }

    private string GetRussianName(DayOfWeek day)
    {
        return day switch
        {
            DayOfWeek.Monday => "Понедельник",
            DayOfWeek.Tuesday => "Вторник",
            DayOfWeek.Wednesday => "Среда",
            DayOfWeek.Thursday => "Четверг",
            DayOfWeek.Friday => "Пятница",
            DayOfWeek.Saturday => "Суббота",
            DayOfWeek.Sunday => "Воскресенье",
            _ => "Неизвестный день"
        };
    }



    public enum DayOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}