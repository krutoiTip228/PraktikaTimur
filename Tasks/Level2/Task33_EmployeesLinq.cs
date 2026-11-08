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
        List<Employee> employees = new List<Employee>
        {
            new Employee("Иван", 25, 50000, "IT"),
            new Employee("Анна", 32, 80000, "IT"),
            new Employee("Петр", 45, 120000, "Management"),
            new Employee("Мария", 28, 60000, "HR"),
            new Employee("Сергей", 35, 95000, "IT"),
            new Employee("Ольга", 40, 110000, "Management"),
            new Employee("Дмитрий", 22, 40000, "Support"),
            new Employee("Елена", 31, 70000, "HR"),
            new Employee("Алексей", 50, 150000, "Management"),
            new Employee("Татьяна", 29, 55000, "Support"),
            new Employee("Максим", 27, 65000, "IT"),
            new Employee("Наталья", 38, 85000, "HR")
        };
        Console.WriteLine("Топ-3 сотрудника по зарплате");
        var top3 = employees
            .OrderByDescending(e => e.Salary)
            .Take(3);

        foreach (var emp in top3)
        {
            Console.WriteLine($"{emp.Name,-10} | {emp.Salary,8} руб. | {emp.Department}");
        }

        Console.WriteLine("\nСредняя зарплата по отделам");
        var avgByDept = employees
            .GroupBy(e => e.Department) 
            .Select(g => new 
            {
                Department = g.Key,
                AverageSalary = g.Average(e => e.Salary)
            });

        foreach (var item in avgByDept)
        {
            Console.WriteLine($"{item.Department,-12} | Средняя: {item.AverageSalary:F2} руб.");
        }

        Console.WriteLine("\nСотрудники старше 30 лет");
        var olderThan30 = employees
            .Where(e => e.Age > 30) 
            .OrderBy(e => e.Age); 
        foreach (var emp in olderThan30)
        {
            Console.WriteLine($"{emp.Name,-10} | Возраст: {emp.Age}");
        }
    }
}

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }

    public Employee(string name, int age, decimal salary, string department)
    {
        Name = name;
        Age = age;
        Salary = salary;
        Department = department;
    }
}