using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;


public class Task22_Params : ITask
{
    public string Title => "params-метод + перегрузка";
    public string Description => "написать метод суммы с params и его перегрузку. ";
    public string[] Requirements => new[]
    {
        "Sum(params int[] numbers) — сумма произвольного числа чисел.",
        "Перегрузка Sum(int[] numbers) — та же логика для массива.",
        "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum().",
        "Пустой вызов — вернуть 0."
    };


    public void Run()
    {
        Console.WriteLine("--- Тестируем метод Sum ---");

   
        int result1 = Sum(1, 2, 3, 4, 5);
        Console.WriteLine($"Sum(1, 2, 3, 4, 5) = {result1}");

      
        int result2 = Sum(10, 20);
        Console.WriteLine($"Sum(10, 20) = {result2}");


        int result3 = Sum();
        Console.WriteLine($"Sum() = {result3}");
    }


    private int Sum(int a, int b)
    {
        return a + b;
    }


    private int Sum(params int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
        {
            return 0;
        }

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }
}