using System;
using System.Globalization;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task14_Age : ITask
{
    public string Title => "14.Возраст по дате рождения";
    public string Description => "по дате рождения вычислить точный возраст в годах, месяцах и днях.";
    public string[] Requirements => new[]
    {
        "Ввод даты через DateTime.TryParse (или TryParseExact).",
        "Учесть, что день рождения в этом году мог ещё не наступить.",
        "Вывести «X лет, Y месяцев, Z дней».",
        "Некорректная дата — сообщение об ошибке, не падать."
    };

    public void Run()
    {
        Console.WriteLine("Введите вашу дату рождения в формате ДД.ММ.ГГГГ");

        bool parsed = DateTime.TryParseExact(
            Console.ReadLine(), "dd.MM.yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None,
            out DateTime birthDate);

        if (!parsed)
        {
            Console.WriteLine("Некорректный формат даты");
            return;
        }

        DateTime today = DateTime.Today;

        if (birthDate > today)
        {
            Console.WriteLine("Ошибка: дата рождения не может быть в будущем");
            return;
        }

        var (years, months, days) = CalculateAge(birthDate, today);
        Console.WriteLine($"\nВаш возраст: {years} лет, {months} месяцев, {days} дней.");
    }

    private static (int Years, int Months, int Days) CalculateAge(DateTime birth, DateTime today)
    {
        int years = today.Year - birth.Year;
        int months = today.Month - birth.Month;
        int days = today.Day - birth.Day;

        // Не хватает дней — занимаем их у предыдущего месяца
        if (days < 0)
        {
            months--;
            DateTime previousMonth = today.AddMonths(-1);
            days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
        }

        // Не хватает месяцев — занимаем у года (именно здесь учитывается, что ДР ещё не наступил)
        if (months < 0)
        {
            months += 12;
            years--;
        }

        return (years, months, days);
    }
}
