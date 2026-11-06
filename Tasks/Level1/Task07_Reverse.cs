using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task07_Reverse : ITask
{

	public string Title => "7.Реверс строки без LINQ";
	public string Description => "перевернуть введённую строку.";
	public string[] Requirements => new[] {

	"Не использовать Array.Reverse и LINQ.",
	"Реализовать через цикл for от конца к началу (или через char[] и swap).",
	"Пустая строка и строка из одного символа — обрабатываются корректно."
	};

	public void Run()
	{
		Console.WriteLine("Введите строку для ревёрса");
		string? vvod = Console.ReadLine();

		vvod ??= string.Empty;

		string reversed = ReverseString(vvod);
		Console.WriteLine($"Оригинал: \"{vvod}\"");
		Console.WriteLine($"Наоборот: \"{reversed}\"");

	}
	private string ReverseString(string text)
	{
		if (text.Length <= 1)
		{
			return text;
		}

		char[] chars = text.ToCharArray();

		string result = "";

		for (int i = chars.Length - 1; i >= 0; i--)
		{
			result += chars[i];

		}
		return result;
	}
}