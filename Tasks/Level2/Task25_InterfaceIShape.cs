using System;
using System.Collections.Generic;
using System.Linq;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task25_InterfaceIShape : ITask
{
    public string Title => "Интерфейс IShape и сортировка фигур";
    public string Description => "Реализовать интерфейс фигур и отсортировать их по площади.";
    public string[] Requirements => new[]
    {
        "IShape с методами Area() и Perimeter()",
        "Классы Circle, Rectangle, Triangle — реализуют IShape",
        "Создать List<IShape> из 5+ фигур",
        "Отсортировать по площади (через List.Sort или OrderBy)",
        "Вывести фигуры с площадями до и после сортировки"
    };

    public void Run()
    {
        var shapes = new List<IShape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5),
            new Circle(2),
            new Rectangle(10, 2)
        };

        Console.WriteLine("--- Фигуры ДО сортировки ---");
        PrintShapes(shapes);

        Console.WriteLine("\n--- Фигуры ПОСЛЕ сортировки (по возрастанию площади) ---");
        PrintShapes(shapes.OrderBy(s => s.Area()));
    }

    private static void PrintShapes(IEnumerable<IShape> shapes)
    {
        foreach (IShape shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name,-12} | Площадь: {shape.Area(),6:F2} | Периметр: {shape.Perimeter(),6:F2}");
        }
    }
}

public interface IShape
{
    double Area();
    double Perimeter();
}

public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius) => Radius = radius;

    public double Area() => Math.PI * Radius * Radius;
    public double Perimeter() => 2 * Math.PI * Radius;
}

public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area() => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
}

public class Triangle : IShape
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public double Perimeter() => SideA + SideB + SideC;

    // Формула Герона
    public double Area()
    {
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }
}
