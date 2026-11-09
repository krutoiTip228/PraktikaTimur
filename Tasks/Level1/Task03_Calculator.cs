using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task03_Calculator : ITask
{
    public string Title => "3. Калькулятор с обработкой деления на ноль";
    public string Description => "принимать два числа и оператор (+ - * /), выводить результат.";
    public string[] Requirements => new[]
    {
        "Оператор обрабатывать через switch.",
        "При делении на ноль — вывести сообщение об ошибке, не ронять приложение.",
        "Некорректный оператор — вывести «Неизвестная операция».",
        "Ввод чисел — через double.Parse или TryParse."
    };

    public void Run()
    {
        if (!TryReadNumber("Введите первое число: ", out double a)) return;
        if (!TryReadNumber("Введите второе число: ", out double b)) return;

        Console.WriteLine("Введите оператор (-, +, *, /)");
        string? op = Console.ReadLine();

        switch (op)
        {
            case "+":
                PrintResult(a + b);
                break;
            case "-":
                PrintResult(a - b);
                break;
            case "*":
                PrintResult(a * b);
                break;
            case "/":
                if (b == 0)
                    Console.WriteLine("Ошибка: Деление на ноль невозможно");
                else
                    PrintResult(a / b);
                break;
            default:
                Console.WriteLine("Неизвестная операция");
                break;
        }
    }

    private static bool TryReadNumber(string prompt, out double number)
    {
        Console.WriteLine(prompt);
        if (double.TryParse(Console.ReadLine(), out number))
            return true;

        Console.WriteLine("Ошибка: Введено не число");
        return false;
    }

    private static void PrintResult(double value) => Console.WriteLine($"Результат: {value}");
}
