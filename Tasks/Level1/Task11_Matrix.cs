using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task11_Matrix : ITask
{

    public string Title => "11.Диагональ матрицы N*N";
    public string Description => "найти сумму элементов главной диагонали матрицы N*N";
    public string[] Requirements => new[] {

    "Размер N вводится пользователем (минимум 2).",
    "Матрица заполняется случайными числами.",
    "Сумма считается без LINQ, в одном цикле for.",
    "Вывести саму матрицу и сумму."

    };
    public void Run()
    {
        int n = 0;

        while (n < 2)
        {
            Console.WriteLine("Введите размер матрицы не меньше 2-ух");
            string? vvod = Console.ReadLine();
            if (!int.TryParse(vvod, out n) || n < 2)
            {
                Console.WriteLine("Ошибка: Нужно ввести число не меньше 2");
                n = 0;
            }
        }

        int[,] matrix = new int[n, n];
        Random rand = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rand.Next(1, 100);
            }
        }
        Console.WriteLine("\nВаша Матрица: ");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],4} ");
            }
            Console.WriteLine();
        }
        int diagonalSum = 0;

        for (int i = 0; i < n; i++)
        {
            diagonalSum += matrix[i, i];
        }
        Console.WriteLine($"\nСумма элементов главной диагонали: {diagonalSum}");

    }
}