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
        Temperature temp = new Temperature();

        Console.WriteLine("Корректное присваивание");
        temp.Celsius = 25.0;
        Console.WriteLine($"Температура: {temp.Celsius}°C");
        Console.WriteLine($"По Фаренгейту: {temp.Fahrenheit:F2}°F\n");

        Console.WriteLine("Некорректное присваивание");
        try
        {
            temp.Celsius = -300.0;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Поймано исключение: {ex.Message}");
        }
    }
}

public class Temperature
{

    private double _celsius;


    public double Celsius
    {
        get
        {
            return _celsius;
        }
        set
        {

            if (value < -273.15)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Температура не может быть ниже абсолютного нуля (-273.15°C)!");
            }
            _celsius = value;
        }
    }

    public double Fahrenheit
    {
        get
        {
            return _celsius * 9 / 5 + 32;
        }
    }
}