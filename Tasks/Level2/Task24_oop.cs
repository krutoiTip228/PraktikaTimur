using System;
using CSharpPraktikum.Common;
using System.Collections.Generic;

namespace CSharpPraktikum.Tasks.Level2;


public class Task24_oop : ITask
{
    public string Title => "ООП: Animal → Dog/Cat/Bird";
    public string Description => "построить иерархию животных.";
    public string[] Requirements => new[]
    {
        "Абстрактный класс Animal: свойство Name, абстрактный метод MakeSound(), переопределённый ToString().",
        "Классы Dog, Cat, Bird — наследники, реализуют MakeSound().",
        "Bird дополнительно имеет метод Fly().",
        "Продемонстрировать полиморфизм: List<Animal> с разными животными, вызов MakeSound() в цикле."

    };

    public void Run()
    {
        List<Animal> animals = new List<Animal> {


        new Dog("Зевс"),
        new Cat("Зевс"),
        new Bird("Зевс"),
        new Dog("Граф")
    };

        Console.WriteLine("Полиморфизм в действии (вызов MakeSound)");


        foreach (Animal animal in animals)
        {

            Console.WriteLine($"Объект: {animal}");
            animal.MakeSound();
            Console.WriteLine();

        }
        Console.WriteLine("--- Дополнительный метод Fly у Bird ---");
        Bird bird = new Bird("Попугай");
        bird.MakeSound();
        bird.Fly();
    }
    public abstract class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }


        public abstract void MakeSound();

        public override string ToString()
        {
            return $"{GetType().Name} по кличке {Name}";
        }
    }


    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine("  Гав-гав!");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine("  Мяу!");
        }
    }

    public class Bird : Animal
    {
        public Bird(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine("  Чирик-чирик!");
        }

        public void Fly()
        {
            Console.WriteLine($"  {Name} летит в небе!");
        }
    }
}