using System;
using System.Collections.Generic;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task28_EqualsGetHashCode : ITask
{
    public string Title => "Equals / GetHashCode для Point";
    public string Description => "Переопределить Equals и GetHashCode для класса Point(x, y).";
    public string[] Requirements => new[]
    {
        "Переопределить Equals(object) и GetHashCode()",
        "Реализовать IEquatable<Point>",
        "Проверить: две точки с одинаковыми координатами равны",
        "Проверить в HashSet<Point>: добавление дубликата не увеличивает Count"
    };

    public void Run()
    {
        Point p1 = new Point(5, 10);
        Point p2 = new Point(5, 10);
        Point p3 = new Point(3, 7);

        Console.WriteLine("Проверка Equals");
        Console.WriteLine($"p1: {p1}");
        Console.WriteLine($"p2: {p2}");
        Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
        Console.WriteLine($"p1 == p3: {p1 == p3}");
        Console.WriteLine();

        Console.WriteLine("Проверка HashSet");

        HashSet<Point> set = new HashSet<Point>();

        set.Add(p1);
        set.Add(p2);
        set.Add(p3);

        Console.WriteLine($"Добавили 3 точки. Количество в HashSet: {set.Count}");
    }
    public class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Point);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        public static bool operator ==(Point? left, Point? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Point? left, Point? right)
        {
            return !Equals(left, right);
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}