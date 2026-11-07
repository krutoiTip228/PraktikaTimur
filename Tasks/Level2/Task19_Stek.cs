using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;


public class Task19_Stek : ITask
{
    public string Title => "Свой стек/очередь на массиве";
    public string Description => "реализовать `MyStack<T>` и `MyQueue<T>` на массиве.  ";
    public string[] Requirements => new[]
    {
        "Стек: `Push`, `Pop`, `Peek`, `Count`, `IsEmpty`.",
        "Очередь: `Enqueue`, `Dequeue`, `Peek`, `Count`, `IsEmpty`.",
        "При переполнении — расширять внутренний массив (удвоение).",
        "`Pop`/`Dequeue` на пустой коллекции — бросать `InvalidOperationException`."
    };
    public void Run()
    {
        Console.WriteLine("Тестируем MyStack (Стек: LIFO - последний зашел, первый вышел)");
        MyStack<int> stack = new MyStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine($"Размер стека: {stack.Count}");
        Console.WriteLine($"Верхний элемент (Peek): {stack.Peek()}");
        Console.WriteLine($"Извлекаем (Pop): {stack.Pop()}");
        Console.WriteLine($"Извлекаем (Pop): {stack.Pop()}");
        Console.WriteLine($"Размер стека теперь: {stack.Count}");
        Console.WriteLine($"Пустой? {stack.IsEmpty()}");
        Console.WriteLine();

        Console.WriteLine("Тестируем MyQueue (Очередь: FIFO - первый зашел, первый вышел)");
        MyQueue<string> queue = new MyQueue<string>();

        queue.Enqueue("Первый");
        queue.Enqueue("Второй");
        queue.Enqueue("Третий");
        Console.WriteLine($"Размер очереди: {queue.Count}");
        Console.WriteLine($"Первый в очереди (Peek): {queue.Peek()}");
        Console.WriteLine($"Извлекаем (Dequeue): {queue.Dequeue()}");
        Console.WriteLine($"Извлекаем (Dequeue): {queue.Dequeue()}");
        Console.WriteLine($"Размер очереди теперь: {queue.Count}");
        Console.WriteLine($"Пустая? {queue.IsEmpty()}");
        Console.WriteLine();

        Console.WriteLine("Проверка ошибки при извлечении из пустой коллекции");
        try
        {
            stack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Поймано исключение: {ex.Message}");
        }
    }
}

public class MyStack<T>
{
    private T[] _items;
    private int _count;

    public MyStack()
    {
        _items = new T[4]; 
        _count = 0;
    }

    public int Count => _count;
    public bool IsEmpty() => _count == 0;

    public void Push(T item)
    {

        if (_count == _items.Length)
        {
            Resize(_items.Length * 2);
        }
        _items[_count] = item;
        _count++;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Стек пуст!");

        _count--;
        T item = _items[_count];
        _items[_count] = default!; 
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Стек пуст!");

        return _items[_count - 1];
    }

    private void Resize(int newSize)
    {
        T[] newArray = new T[newSize];
        Array.Copy(_items, newArray, _count);
        _items = newArray;
    }
}

public class MyQueue<T>
{
    private T[] _items;
    private int _head; 
    private int _tail;
    private int _count;

    public MyQueue()
    {
        _items = new T[4];
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    public int Count => _count;
    public bool IsEmpty() => _count == 0;

    public void Enqueue(T item)
    {
        if (_count == _items.Length)
        {
            Resize(_items.Length * 2);
        }
        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Очередь пуста!");

        T item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Очередь пуста!");

        return _items[_head];
    }

    private void Resize(int newSize)
    {
        T[] newArray = new T[newSize];

        
        for (int i = 0; i < _count; i++)
        {
            newArray[i] = _items[(_head + i) % _items.Length];
        }

        _items = newArray;
        _head = 0;
        _tail = _count;
    }
}