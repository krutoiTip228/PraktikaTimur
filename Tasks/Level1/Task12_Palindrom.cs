using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task12_Palindrom : ITask
{
    public string Title => "12.Палиндром (без учёта регистра/пробелов)";
    public string Description => "проверить, является ли строка палиндромом.";
    public string[] Requirements => new[]
    {
        "Игнорировать регистр (ToLower/ToUpper).",
        "Игнорировать пробелы и знаки пунктуации (или хотя бы пробелы).",
        "Не использовать LINQ Reverse.",
        "Пустая строка и строка из одного символа — палиндром."
    };

    public void Run()
    {
        Console.WriteLine("Введите строку, которую нужно проверить:");
        string input = Console.ReadLine() ?? string.Empty;

        Console.WriteLine($"Строка \"{input}\" является палиндромом: {IsPalindrome(input)}");
    }

    // Два указателя идут навстречу друг другу, пропуская всё, что не буква и не цифра.
    // Для пустой строки и одного символа цикл не выполняется — результат true.
    private static bool IsPalindrome(string text)
    {
        int left = 0;
        int right = text.Length - 1;

        while (left < right)
        {
            if (!char.IsLetterOrDigit(text[left]))
            {
                left++;
            }
            else if (!char.IsLetterOrDigit(text[right]))
            {
                right--;
            }
            else
            {
                if (char.ToLower(text[left]) != char.ToLower(text[right]))
                    return false;

                left++;
                right--;
            }
        }

        return true;
    }
}
