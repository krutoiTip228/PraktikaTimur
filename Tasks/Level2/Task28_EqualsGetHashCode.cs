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
        var p1 = new Point(5, 10);
        var p2 = new Point(5, 10);
        var p3 = new Point(3, 7);

        Console.WriteLine("Проверка Equals");
        Console.WriteLine($"p1 = {p1}, p2 = {p2}, p3 = {p3}");
        Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
        Console.WriteLine($"p1 == p2: {p1 == p2}");
        Console.WriteLine($"p1 == p3: {p1 == p3}\n");

        Console.WriteLine("Проверка HashSet");
        var set = new HashSet<Point> { p1, p2, p3 };
        Console.WriteLine($"Добавили 3 точки (две одинаковые). Количество в HashSet: {set.Count}");
    }

    public sealed class Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point? other)
        {
            return other is not null && X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj) => Equals(obj as Point);

        // Должен совпадать для равных точек — иначе HashSet не найдёт дубликат
        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Point? left, Point? right) => Equals(left, right);
        public static bool operator !=(Point? left, Point? right) => !Equals(left, right);

        public override string ToString() => $"({X}, {Y})";
    }
}
