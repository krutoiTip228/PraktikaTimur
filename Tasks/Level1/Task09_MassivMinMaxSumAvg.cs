using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task09_MassivMinMaxSumAvg : ITask
{

    public string Title => "9.Массивы: min/max/sum/avg";
    public string Description => "для массива чисел найти минимум, максимум, сумму и среднее.";
    public string[] Requirements => new[] {

    "Заполнить массив (например, случайными числами 1–100, размер 20).",
    "Реализовать без LINQ (Min/Max/Sum/Average запрещены).",
    "Оформить 4 отдельных метода.",
    "Пустой массив — обработать (вернуть ошибку или 0, но не падать)."
    };

    public void Run()
    {
        int[] massive = new int [20];
        Random rand = new Random();

        for(int i = 0; i<massive.Length; i++)
        {
            massive[i] = rand.Next(1,101);
        }
        Console.WriteLine("Массив: " + string.Join(", ", massive));
        Console.WriteLine();

       
        Console.WriteLine($"Минимум:  {FindMin(massive)}");
        Console.WriteLine($"Максимум: {FindMax(massive)}");
        Console.WriteLine($"Сумма:    {FindSum(massive)}");
        Console.WriteLine($"Среднее:  {FindAverage(massive):F2}"); 
    }

   
    private int FindMin(int[] arr)
    {

        if (arr.Length == 0) return 0;

        int min = arr[0]; 
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i]; 
            }
        }
        return min;
    }


    private int FindMax(int[] arr)
    {
        if (arr.Length == 0) return 0;

        int max = arr[0]; 
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i]; 
            }
        }
        return max;
    }

    
    private int FindSum(int[] arr)
    {
        if (arr.Length == 0) return 0;

        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }


    private double FindAverage(int[] arr)
    {
        if (arr.Length == 0) return 0;


        int sum = FindSum(arr);


        return (double)sum / arr.Length;
    }
}
    