using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task11_Matrix : ITask
{
    private const int MinSize = 2;

    public string Title => "11.Диагональ матрицы N*N";
    public string Description => "найти сумму элементов главной диагонали матрицы N*N";
    public string[] Requirements => new[]
    {
        "Размер N вводится пользователем (минимум 2).",
        "Матрица заполняется случайными числами.",
        "Сумма считается без LINQ, в одном цикле for.",
        "Вывести саму матрицу и сумму."
    };

    public void Run()
    {
        int size = ReadSize();
        int[,] matrix = CreateRandomMatrix(size);

        Console.WriteLine("\nВаша матрица:");
        PrintMatrix(matrix);

        Console.WriteLine($"\nСумма элементов главной диагонали: {DiagonalSum(matrix)}");
    }

    private static int ReadSize()
    {
        while (true)
        {
            Console.WriteLine($"Введите размер матрицы (не меньше {MinSize}):");

            if (int.TryParse(Console.ReadLine(), out int size) && size >= MinSize)
                return size;

            Console.WriteLine($"Ошибка: нужно ввести целое число не меньше {MinSize}");
        }
    }

    private static int[,] CreateRandomMatrix(int size)
    {
        var random = new Random();
        var matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                matrix[i, j] = random.Next(1, 100);
        }

        return matrix;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                Console.Write($"{matrix[i, j],4} ");
            Console.WriteLine();
        }
    }

    private static int DiagonalSum(int[,] matrix)
    {
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            sum += matrix[i, i];
        return sum;
    }
}
