using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level1;

public class Task02_PerPrimTip : ITask
{

	public string Title => "2.Переменные примитивных типов";
	public string Description => "объявить переменные всех примитивных типов и вывести их значения и типы.";
	public string[] Requirements => new[] {

	"Объявить минимум: int, long, double, float, decimal, bool, char, string.",
	"Для каждой переменной вывести значение и GetType().Name.",
	"decimal — с суффиксом m, float — с f."
	};

	public void Run()
	{
		Console.WriteLine("Все переменные и их типы");
		Console.WriteLine();

		int CeloeChislo = 20;
		Console.WriteLine($"1.{CeloeChislo}  ({CeloeChislo.GetType().Name})");

		long dlinnoeNechto = 3000000000L;
		Console.WriteLine($"2. {dlinnoeNechto} ({dlinnoeNechto.GetType().Name})");

		double Dable = 4.15649;
		Console.WriteLine($"3.{Dable} ({Dable.GetType().Name})");

		float PlavTochka = 43f;
		Console.WriteLine($"4.{PlavTochka} ({PlavTochka.GetType().Name})");

		decimal huzheDable = 99.9m;
		Console.WriteLine($"5. {huzheDable} ({huzheDable.GetType().Name})");

		bool PravdaLosh = true;
		Console.WriteLine($"6. {PravdaLosh} ({PravdaLosh.GetType().Name})");

		char Symbol = 'A';
		Console.WriteLine($"7. {Symbol} ({Symbol.GetType().Name})");

		string predlojenie = "аыаыаыаы,ываыва ыыы, ввв";
		Console.WriteLine($"8. {predlojenie} ({predlojenie.GetType().Name})");


	} 
}