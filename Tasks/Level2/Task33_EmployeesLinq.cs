using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task33_EmployeesLinq : ITask
{
    public string Title => "LINQ: сотрудники";
    public string Description => "LINQ-запросы по списку сотрудников.";
    public string[] Requirements => new[]
    {
        "Класс Employee: Name, Age, Salary, Department",
        "Список из 10+ сотрудников",
        "Топ-3 по зарплате (убывание)",
        "Средняя зарплата по каждому отделу (GroupBy + Average)",
        "Сотрудники старше 30 (Where)"
    };

    public void Run()
    {
        List<Employee> employees = CreateEmployees();

        Console.WriteLine("Топ-3 сотрудника по зарплате");
        var top3 = employees.OrderByDescending(e => e.Salary).Take(3);
        foreach (Employee e in top3)
            Console.WriteLine($"{e.Name,-10} | {e.Salary,8} руб. | {e.Department}");

        Console.WriteLine("\nСредняя зарплата по отделам");
        var averages = employees
            .GroupBy(e => e.Department)
            .Select(g => new { Department = g.Key, Average = g.Average(e => e.Salary) });
        foreach (var item in averages)
            Console.WriteLine($"{item.Department,-12} | Средняя: {item.Average:F2} руб.");

        Console.WriteLine("\nСотрудники старше 30 лет");
        var older = employees.Where(e => e.Age > 30).OrderBy(e => e.Age);
        foreach (Employee e in older)
            Console.WriteLine($"{e.Name,-10} | Возраст: {e.Age}");
    }

    private static List<Employee> CreateEmployees() => new()
    {
        new("Иван", 25, 50000, "IT"),
        new("Анна", 32, 80000, "IT"),
        new("Петр", 45, 120000, "Management"),
        new("Мария", 28, 60000, "HR"),
        new("Сергей", 35, 95000, "IT"),
        new("Ольга", 40, 110000, "Management"),
        new("Дмитрий", 22, 40000, "Support"),
        new("Елена", 31, 70000, "HR"),
        new("Алексей", 50, 150000, "Management"),
        new("Татьяна", 29, 55000, "Support"),
        new("Максим", 27, 65000, "IT"),
        new("Наталья", 38, 85000, "HR")
    };
}

public class Employee
{
    public string Name { get; }
    public int Age { get; }
    public decimal Salary { get; }
    public string Department { get; }

    public Employee(string name, int age, decimal salary, string department)
    {
        Name = name;
        Age = age;
        Salary = salary;
        Department = department;
    }
}
