using System;
using System.Linq;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;


public class Task16_StringExtensions : ITask
{
    public string Title => "Методы расширения для string";
    public string Description => "Добавить методы IsPalindrome, WordCount и ReverseString к типу string.";
    public string[] Requirements => new[]
    {
        "Реализовать в статическом классе StringExtensions",
        "Методы public static с this string первым параметром",
        "Продемонстрировать вызов на 2–3 строках"
    };

    public void Run()
    {
        string text1 = "А роза упала на лапу Азора";
        string text2 = "Hello, World!";
        string text3 = "C# is awesome";

        Console.WriteLine($"Строка: \"{text1}\"");
        Console.WriteLine($"Палиндром? {text1.IsPalindrome()}");
        Console.WriteLine();


        Console.WriteLine($"Строка: \"{text2}\"");
        Console.WriteLine($"Количество слов: {text2.WordCount()}");
        Console.WriteLine();


        Console.WriteLine($"Строка: \"{text3}\"");
        Console.WriteLine($"Реверс: \"{text3.ReverseString()}\"");
    }
}


public static class StringExtensions
{
 
    public static bool IsPalindrome(this string str)
    {
        if (string.IsNullOrEmpty(str)) return true;

  
        var clean = new string(str.ToLower().Where(char.IsLetterOrDigit).ToArray());


        return clean == new string(clean.Reverse().ToArray());
    }

    public static int WordCount(this string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return 0;

      
        string[] words = str.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }


    public static string ReverseString(this string str)
    {
        if (string.IsNullOrEmpty(str)) return str;

        char[] chars = str.ToCharArray();
        Array.Reverse(chars); 
        return new string(chars);
    }
}