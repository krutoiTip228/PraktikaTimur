using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task09_MassivMinMaxSumAvg : ITask
{
    private const int ArraySize = 20;

    public string Title => "9.Массивы: min/max/sum/avg";
    public string Description => "для массива чисел найти минимум, максимум, сумму и среднее.";
    public string[] Requirements => new[]
    {
        "Заполнить массив (например, случайными числами 1–100, размер 20).",
        "Реализовать без LINQ (Min/Max/Sum/Average запрещены).",
        "Оформить 4 отдельных метода.",
        "Пустой массив — обработать (вернуть ошибку или 0, но не падать)."
    };

    public void Run()
    {
        int[] numbers = CreateRandomArray(ArraySize);

        Console.WriteLine("Массив: " + string.Join(", ", numbers));
        Console.WriteLine();
        Console.WriteLine($"Минимум:  {FindMin(numbers)}");
        Console.WriteLine($"Максимум: {FindMax(numbers)}");
        Console.WriteLine($"Сумма:    {FindSum(numbers)}");
        Console.WriteLine($"Среднее:  {FindAverage(numbers):F2}");
    }

    private static int[] CreateRandomArray(int size)
    {
        var random = new Random();
        int[] array = new int[size];

        for (int i = 0; i < array.Length; i++)
            array[i] = random.Next(1, 101);

        return array;
    }

    private static int FindMin(int[] array)
    {
        if (array.Length == 0) return 0;

        int min = array[0];
        foreach (int value in array)
        {
            if (value < min) min = value;
        }
        return min;
    }

    private static int FindMax(int[] array)
    {
        if (array.Length == 0) return 0;

        int max = array[0];
        foreach (int value in array)
        {
            if (value > max) max = value;
        }
        return max;
    }

    private static int FindSum(int[] array)
    {
        int sum = 0;
        foreach (int value in array)
            sum += value;
        return sum;
    }

    private static double FindAverage(int[] array)
    {
        return array.Length == 0 ? 0 : (double)FindSum(array) / array.Length;
    }
}
