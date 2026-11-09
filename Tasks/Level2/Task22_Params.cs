using System;
using System.Collections.Generic;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task22_Params : ITask
{
    public string Title => "params-метод + перегрузка";
    public string Description => "написать метод суммы с params и его перегрузку. ";
    public string[] Requirements => new[]
    {
        "Sum(params int[] numbers) — сумма произвольного числа чисел.",
        "Перегрузка Sum(int[] numbers) — та же логика для массива.",
        "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum().",
        "Пустой вызов — вернуть 0."
    };

    public void Run()
    {
        Console.WriteLine("--- Тестируем метод Sum ---");

        Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}");
        Console.WriteLine($"Sum(new[] {{1, 2, 3}}) = {Sum(new[] { 1, 2, 3 })}");
        Console.WriteLine($"Sum() = {Sum()}");
        Console.WriteLine($"Sum(List {{4, 5, 6}}) = {Sum(new List<int> { 4, 5, 6 })}");
    }

    // Перегрузка с params: можно передавать числа через запятую, массив или ничего
    private static int Sum(params int[] numbers)
    {
        return Sum((IEnumerable<int>)numbers);
    }

    // Перегрузка для любой коллекции чисел. Отдельный Sum(int[]) нельзя:
    // он совпадал бы по сигнатуре с params int[] и не скомпилировался бы
    private static int Sum(IEnumerable<int>? numbers)
    {
        int total = 0;

        if (numbers is null)
            return total;

        foreach (int number in numbers)
            total += number;

        return total;
    }
}
