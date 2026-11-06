using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task14_Age : ITask
{

    public string Title => "14.Возраст по дате рождения";
    public string Description => "по дате рождения вычислить точный возраст в годах, месяцах и днях.";
    public string[] Requirements => new[] {

    "Ввод даты через DateTime.TryParse (или TryParseExact).",
    "Учесть, что день рождения в этом году мог ещё не наступить.",
    "Вывести «X лет, Y месяцев, Z дней».",
    "Некорректная дата — сообщение об ошибке, не падать."

    };

    public void Run()
    {
        Console.WriteLine("Введите вашу дату рождения в формате ДД.ММ.ГГГГ");
        string? vvod = Console.ReadLine();

        if (!DateTime.TryParse(vvod, out DateTime birthDate))
        {
            Console.WriteLine("Некорректный формат даты");
            return;
        }
        DateTime today = DateTime.Today;

        if (birthDate > today)
        {
            Console.WriteLine("Ошибка: Дата рождения не может быть в будущем");
            return;
        }
        int years = today.Year - birthDate.Year;
        int months = today.Month - birthDate.Month;
        int days = today.Day - birthDate.Day;


        if (today.Month < birthDate.Month || (today.Month == birthDate.Month && today.Day < birthDate.Day))
        {
            years--;
        }

        if (days < 0)
        {
            months--;


            DateTime previousMonth = today.AddMonths(-1);
            days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);

        }
        if (months < 0)
        {
            months += 12;
            years--;
        }

        Console.WriteLine($"\nВаш возраст: {years} лет, {months} месяцев, {days} дней.");

    }
}