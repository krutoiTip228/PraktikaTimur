using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task03_Calculator : ITask
{

	public string Title => "3. Калькулятор с обработкой деления на ноль";
	public string Description => "принимать два числа и оператор (+ - * /), выводить результат.";
	public string[] Requirements => new[] {

	"Оператор обрабатывать через switch.",
	"При делении на ноль — вывести сообщение об ошибке, не ронять приложение.",
	"Некорректный оператор — вывести «Неизвестная операция».",
	"Ввод чисел — через double.Parse или TryParse."
	};
	public void Run()
	{

		Console.WriteLine("Введите первое число: ");
		string? input1 = Console.ReadLine();

		if (!double.TryParse(input1, out double num1))
		{
			Console.WriteLine("Ошибка: Введено не число");
			return;
		}
		Console.WriteLine("Введите второе число: ");
		string? input2 = Console.ReadLine();

		if (!double.TryParse(input2, out double num2))
		{

			Console.WriteLine("Ошибка: Введено не число");
			return;

		}

		Console.WriteLine("Введите оператор (-, +, *, /)");
		string? op = Console.ReadLine();

		switch (op)
			{


				case "+":
				Console.WriteLine($"Результат: {num1 + num2} ");
				break;

			case "-":
				Console.WriteLine($"Результа: {num1 - num2} ");
				break;

			case "*":
				Console.WriteLine($"Результат: {num1 * num2} ");
				break;
			case "/":

				if (num2 == 0)
				{

					Console.WriteLine("Ошибка: Деление на ноль невозможно");

				}
				else
				{

					Console.WriteLine($"Результат: {num1 / num2}");



				}

				break;
			default:
				Console.WriteLine("Неизвестная операция");
				break;

			}
		} 
	}