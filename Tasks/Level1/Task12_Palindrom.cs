using System;
using System.Text;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task12_Palindrom : ITask
{

    public string Title => "12.Палиндром (без учёта регистра/пробелов)";
    public string Description => "проверить, является ли строка палиндромом.";
    public string[] Requirements => new[] {

    "Игнорировать регистр (ToLower/ToUpper).",
    "Игнорировать пробелы и знаки пунктуации (или хотя бы пробелы).",
    "Не использовать LINQ Reverse.",
    "Пустая строка и строка из одного символа — палиндром."
    
    };

    public void Run()
    {
        Console.WriteLine("Введите строку, которую нужно првоерить:");
        string? vvod = Console.ReadLine();

        if (string.IsNullOrEmpty(vvod))
        {
            Console.WriteLine("Строка пуста. Считается палиндромом");
            return;
        }
        bool isPalindrom = IsPalindrom(vvod);

        Console.WriteLine($"Строка \"{vvod}\" является палиндромом: {isPalindrom} ");
    }

    private bool IsPalindrom(string text)
    {
        text = text.ToLower();


        StringBuilder cleantext = new StringBuilder();

        foreach(char c in text )
        {
            if (char.IsLetterOrDigit(c))
            {
                cleantext.Append(c);
            }
        }
        string finalString = cleantext.ToString();

        int left = 0;
        int right = finalString.Length - 1;

        while (left < right)
        {
            if (finalString[left] != finalString[right])
            {
                return false; 
            }
            left++;
            right--;
        }

        return true; 
    }
}