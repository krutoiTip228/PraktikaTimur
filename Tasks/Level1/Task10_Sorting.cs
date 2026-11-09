using System;
using System.Diagnostics;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task10_Sorting : ITask
{
    private const int ArraySize = 10_000;

    public string Title => "10.Сортировка пузырьком + вставками";
    public string Description => "отсортировать массив двумя алгоритмами.";
    public string[] Requirements => new[]
    {
        "Реализовать BubbleSort и InsertionSort отдельными методами.",
        "Оба — без LINQ и Array.Sort.",
        "Замерить время каждого через Stopwatch на массиве 10 000 элементов.",
        "Вывести оба времени."
    };

    public void Run()
    {
        var random = new Random();
        int[] source = new int[ArraySize];
        for (int i = 0; i < source.Length; i++)
            source[i] = random.Next(1, 10_000);

        // Каждому алгоритму — своя копия одних и тех же данных
        int[] forBubble = (int[])source.Clone();
        int[] forInsertion = (int[])source.Clone();

        Console.WriteLine($"Массив из {ArraySize} элементов создан. Начинаем сортировку...\n");

        long bubbleMs = MeasureMilliseconds(() => BubbleSort(forBubble));
        Console.WriteLine($"Пузырьковая сортировка: {bubbleMs} мс");

        long insertionMs = MeasureMilliseconds(() => InsertionSort(forInsertion));
        Console.WriteLine($"Сортировка вставками:   {insertionMs} мс");

        Console.WriteLine($"\nРезультаты сортировок совпадают: {AreEqual(forBubble, forInsertion)}");
    }

    private static long MeasureMilliseconds(Action action)
    {
        var stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    private static bool AreEqual(int[] first, int[] second)
    {
        if (first.Length != second.Length) return false;

        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i]) return false;
        }
        return true;
    }

    private static void BubbleSort(int[] array)
    {
        for (int pass = 0; pass < array.Length - 1; pass++)
        {
            bool swapped = false;

            for (int j = 0; j < array.Length - 1 - pass; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    swapped = true;
                }
            }

            if (!swapped) break; // массив уже отсортирован
        }
    }

    private static void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }
}
