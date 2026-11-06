using System;
using System.Diagnostics;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task10_Sorting : ITask
{

    public string Title => "10.Сортировка пузырьком + вставками";
    public string Description => "отсортировать массив двумя алгоритмами.";
    public string[] Requirements => new[] {

    "Реализовать BubbleSort и InsertionSort отдельными методами.",
    "Оба — без LINQ и Array.Sort.",
    "Замерить время каждого через Stopwatch на массиве 10 000 элементов.",
    "Вывести оба времени."
    };

    public void Run()
    {
        int razmer = 10000;
        Random rand = new Random();

        int[] massiv1 = new int[razmer];
        int[] massiv2 = new int[razmer];

        for (int i = 0; i < razmer; i++)
        {
            int num = rand.Next(1, 10000);
            massiv1[i] = num;
            massiv2[i] = num;
        }
        Console.WriteLine($"Массив из {razmer} элементов создан. Начинаем сортировку...\n");

        Stopwatch sw1 = Stopwatch.StartNew();
        BubbleSort(massiv1);
        sw1.Stop();
        Console.WriteLine($"Пузырьковая сортировка: {sw1.ElapsedMilliseconds} мс");



        Stopwatch sw2 = Stopwatch.StartNew();
        InsertionSort(massiv2);
        sw2.Stop();
        Console.WriteLine($" Сортировка вставками: {sw2.ElapsedMilliseconds} мс");


        bool isEqual = true;
        for (int i = 0; i < razmer; i++)
        {
            if (massiv1[i] == massiv2[i])
            {
                isEqual = false;
                break;
            }

        }
        Console.WriteLine($"\nРезультаты сортировок совпадают: {isEqual}");

    }
    
    private void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++) {

            bool swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                  
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
           
            if (!swapped) break;
        }
    }

private void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i]; 
            int j = i - 1;

           
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
        
            arr[j + 1] = key;
        }
    }
}




