using System;
using System.Collections.Generic;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task27_IComparableIComparerTforStudent : ITask
{
    public string Title => "Сортировка Student (IComparable / IComparer)";
    public string Description => "Научить класс Student сортироваться по среднему баллу и по имени.";
    public string[] Requirements => new[]
    {
        "Класс Student: Name, AverageGrade",
        "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию)",
        "Реализовать IComparer<Student> ByNameComparer — сортировка по имени",
        "Продемонстрировать обе сортировки на List<Student>"
    };

    public void Run()
    {
        var students = new List<Student>
        {
            new("Инокентий", 1.2),
            new("Антон", 3.4),
            new("Марк", 4.2),
            new("Павел", 5.0)
        };

        Console.WriteLine("Исходный список");
        PrintList(students);

        students.Sort(); // IComparable<Student>: по среднему баллу, по убыванию
        Console.WriteLine("\nСортировка по среднему баллу (убывание)");
        PrintList(students);

        students.Sort(new ByNameComparer()); // IComparer<Student>: по имени
        Console.WriteLine("\nСортировка по имени");
        PrintList(students);
    }

    private static void PrintList(List<Student> students)
    {
        foreach (Student student in students)
            Console.WriteLine($"  {student.Name,-10} | Балл: {student.AverageGrade}");
    }
}

public class Student : IComparable<Student>
{
    public string Name { get; }
    public double AverageGrade { get; }

    public Student(string name, double averageGrade)
    {
        Name = name;
        AverageGrade = averageGrade;
    }

    // Аргументы поменяны местами, чтобы получить порядок по убыванию
    public int CompareTo(Student? other)
    {
        return other is null ? 1 : other.AverageGrade.CompareTo(AverageGrade);
    }
}

public class ByNameComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        return string.CompareOrdinal(x?.Name, y?.Name);
    }
}
