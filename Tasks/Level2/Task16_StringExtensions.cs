using System;
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
        string palindromeText = "А роза упала на лапу Азора";
        string wordsText = "Hello, World!";
        string reverseText = "C# is awesome";

        Console.WriteLine($"Строка: \"{palindromeText}\"");
        Console.WriteLine($"Палиндром? {palindromeText.IsPalindrome()}\n");

        Console.WriteLine($"Строка: \"{wordsText}\"");
        Console.WriteLine($"Количество слов: {wordsText.WordCount()}\n");

        Console.WriteLine($"Строка: \"{reverseText}\"");
        Console.WriteLine($"Реверс: \"{reverseText.ReverseString()}\"");
    }
}

public static class StringExtensions
{
    private static readonly char[] WordSeparators = { ' ', '.', ',', '!', '?', ':', ';' };

    // Два указателя навстречу друг другу, пропуская не-буквы и не-цифры
    public static bool IsPalindrome(this string text)
    {
        int left = 0;
        int right = text.Length - 1;

        while (left < right)
        {
            if (!char.IsLetterOrDigit(text[left])) { left++; continue; }
            if (!char.IsLetterOrDigit(text[right])) { right--; continue; }

            if (char.ToLower(text[left]) != char.ToLower(text[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }

    public static int WordCount(this string text)
    {
        return string.IsNullOrWhiteSpace(text)
            ? 0
            : text.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static string ReverseString(this string text)
    {
        char[] chars = text.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}
