using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task21_enum : ITask
{
    // Вложенный enum, поэтому внутри класса имя DayOfWeek относится к нему, а не к System.DayOfWeek
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

    public string Title => "enum дни недели";
    public string Description => "описать дни недели через enum и определить тип дня.";
    public string[] Requirements => new[]
    {
        "enum DayOfWeek { Monday, ..., Sunday }.",
        "Метод IsWeekend(DayOfWeek day) — true для субботы и воскресенья.",
        "Метод GetRussianName(DayOfWeek day) — возвращает название на русском.",
        "Продемонстрировать на всех 7 днях."
    };

    public void Run()
    {
        foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>())
        {
            string dayType = IsWeekend(day) ? "Выходной" : "Рабочий";
            Console.WriteLine($"{day,-10} ({GetRussianName(day),-12}) -> {dayType}");
        }
    }

    private static bool IsWeekend(DayOfWeek day)
    {
        return day is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }

    private static string GetRussianName(DayOfWeek day) => day switch
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
