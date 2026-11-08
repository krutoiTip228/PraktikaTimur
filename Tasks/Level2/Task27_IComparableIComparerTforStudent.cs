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
        List<Student> students = new List<Student>
        {
            new Student("Инокентий", 1.2),
            new Student("Антон", 3.4),
            new Student("Марк", 4.2),
            new Student("Павел", 5.0),
        };
        Console.WriteLine("Исходный список");
        PrintList(students);


        students.Sort();


        Console.WriteLine("Сортировка по среднему баллу");
        PrintList(students);



        students.Sort(new ByNameComparer());

        Console.WriteLine("Сортировка по имени");
        PrintList(students);


    }

    private void PrintList(List<Student> list)
    {
        foreach (var s in list)
        {
            Console.WriteLine($"  {s.Name,-10} | Балл: {s.AverageGrade}");
        }
    }
}


public class Student : IComparable<Student>
{
    public string Name { get; set; }
    public double AverageGrade { get; set; }

    public Student(string name, double averageGrade)
    {
        Name = name;
        AverageGrade = averageGrade;
    }

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;

        return other.AverageGrade.CompareTo(this.AverageGrade);
    }
}

public class ByNameComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null || y == null) return 0;
       
        return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
}