using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task06_DigitSum : ITask
{

    public string Title => "6. Сумма цифр числа (строка + арифметика)";
    public string Description => "найти сумму цифр введённого числа (например, 1234 → 10).";
    public string[] Requirements => new[] {

    "Способ 1 (строка): число → ToString() → пройти по символам → int.Parse каждой цифры.",
    "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }.",
    "Оба способа оформить отдельными методами.",
    "Отрицательные числа — брать модуль."
    };

    public void Run()

    {
        Console.WriteLine("Введите число:");
        string? vvod = Console.ReadLine();

        if (!int.TryParse(vvod, out int number))
        {
            Console.WriteLine("Ошибка: Нужно ввести целое число");
            return;
        }
        int sumString = SumByString(number);
        int sumMath = SumByMath(number);

        Console.WriteLine($"Способ 1 (через строку): {sumString}");
        Console.WriteLine($"Способ 2 (через математику): {sumMath}");
    }
        private int SumByString(int number)
    {
        number = Math.Abs(number);

        string text = number.ToString();
        int sum = 0;

        foreach (char c in text)
        {
            sum += int.Parse(c.ToString());
        }
        return sum;
    }
    private int SumByMath(int number)
    {
        number = Math.Abs(number);
        int sum = 0;

        while (number > 0)
        {

            int lastDigit = number % 10;
            sum += lastDigit;

            number /= 10;

        }
        return sum;
    }
}