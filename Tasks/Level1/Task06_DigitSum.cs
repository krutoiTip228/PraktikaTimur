using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task06_DigitSum : ITask
{
    public string Title => "6. Сумма цифр числа (строка + арифметика)";
    public string Description => "найти сумму цифр введённого числа (например, 1234 → 10).";
    public string[] Requirements => new[]
    {
        "Способ 1 (строка): число → ToString() → пройти по символам → int.Parse каждой цифры.",
        "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }.",
        "Оба способа оформить отдельными методами.",
        "Отрицательные числа — брать модуль."
    };

    public void Run()
    {
        Console.WriteLine("Введите число:");

        if (!int.TryParse(Console.ReadLine(), out int input))
        {
            Console.WriteLine("Ошибка: Нужно ввести целое число");
            return;
        }

        // Приводим к long, чтобы Math.Abs не падал на int.MinValue
        long number = Math.Abs((long)input);

        Console.WriteLine($"Способ 1 (через строку): {SumByString(number)}");
        Console.WriteLine($"Способ 2 (через арифметику): {SumByArithmetic(number)}");
    }

    private static int SumByString(long number)
    {
        int sum = 0;
        foreach (char digit in number.ToString())
            sum += int.Parse(digit.ToString());
        return sum;
    }

    private static int SumByArithmetic(long number)
    {
        int sum = 0;
        while (number > 0)
        {
            sum += (int)(number % 10);
            number /= 10;
        }
        return sum;
    }
}
