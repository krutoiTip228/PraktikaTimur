using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task32_temperatura : ITask
{
    public string Title => "Свойства с валидацией (Temperature)";
    public string Description => "Класс Temperature с валидацией в set и вычисляемым свойством Fahrenheit.";
    public string[] Requirements => new[]
    {
        "Свойство Celsius с проверкой в set: не ниже -273.15",
        "При некорректном значении — бросать ArgumentOutOfRangeException",
        "Вычисляемое свойство Fahrenheit (только get)",
        "Продемонстрировать корректное и некорректное присваивание"
    };

    public void Run()
    {
        var temperature = new Temperature();

        Console.WriteLine("Корректное присваивание");
        temperature.Celsius = 25.0;
        Console.WriteLine($"Температура: {temperature.Celsius}°C");
        Console.WriteLine($"По Фаренгейту: {temperature.Fahrenheit:F2}°F\n");

        Console.WriteLine("Некорректное присваивание");
        try
        {
            temperature.Celsius = -300.0;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Поймано исключение: {ex.Message}");
        }
    }
}

public class Temperature
{
    private const double AbsoluteZero = -273.15;
    private double _celsius;

    public double Celsius
    {
        get => _celsius;
        set
        {
            if (value < AbsoluteZero)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"Температура не может быть ниже абсолютного нуля ({AbsoluteZero}°C)!");
            }

            _celsius = value;
        }
    }

    public double Fahrenheit => _celsius * 9 / 5 + 32;
}
