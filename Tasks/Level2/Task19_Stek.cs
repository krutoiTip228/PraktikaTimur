using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task19_Stek : ITask
{
    public string Title => "Свой стек/очередь на массиве";
    public string Description => "реализовать `MyStack<T>` и `MyQueue<T>` на массиве.  ";
    public string[] Requirements => new[]
    {
        "Стек: `Push`, `Pop`, `Peek`, `Count`, `IsEmpty`.",
        "Очередь: `Enqueue`, `Dequeue`, `Peek`, `Count`, `IsEmpty`.",
        "При переполнении — расширять внутренний массив (удвоение).",
        "`Pop`/`Dequeue` на пустой коллекции — бросать `InvalidOperationException`."
    };

    public void Run()
    {
        DemoStack();
        Console.WriteLine();
        DemoQueue();
        Console.WriteLine();
        DemoEmptyCollections();
    }

    private static void DemoStack()
    {
        Console.WriteLine("Тестируем MyStack (LIFO — последний зашёл, первый вышел)");
        var stack = new MyStack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine($"Размер стека: {stack.Count}");
        Console.WriteLine($"Верхний элемент (Peek): {stack.Peek()}");
        Console.WriteLine($"Извлекаем (Pop): {stack.Pop()}");
        Console.WriteLine($"Извлекаем (Pop): {stack.Pop()}");
        Console.WriteLine($"Размер стека теперь: {stack.Count}");
        Console.WriteLine($"Пустой? {stack.IsEmpty()}");
    }

    private static void DemoQueue()
    {
        Console.WriteLine("Тестируем MyQueue (FIFO — первый зашёл, первый вышел)");
        var queue = new MyQueue<string>();

        queue.Enqueue("Первый");
        queue.Enqueue("Второй");
        queue.Enqueue("Третий");
        Console.WriteLine($"Размер очереди: {queue.Count}");
        Console.WriteLine($"Первый в очереди (Peek): {queue.Peek()}");
        Console.WriteLine($"Извлекаем (Dequeue): {queue.Dequeue()}");
        Console.WriteLine($"Извлекаем (Dequeue): {queue.Dequeue()}");
        Console.WriteLine($"Размер очереди теперь: {queue.Count}");
        Console.WriteLine($"Пустая? {queue.IsEmpty()}");
    }

    private static void DemoEmptyCollections()
    {
        Console.WriteLine("Проверка ошибки при извлечении из пустой коллекции");

        try { new MyStack<int>().Pop(); }
        catch (InvalidOperationException ex) { Console.WriteLine($"Стек: {ex.Message}"); }

        try { new MyQueue<int>().Dequeue(); }
        catch (InvalidOperationException ex) { Console.WriteLine($"Очередь: {ex.Message}"); }
    }
}

public class MyStack<T>
{
    private const int InitialCapacity = 4;
    private T[] _items = new T[InitialCapacity];

    public int Count { get; private set; }

    public bool IsEmpty() => Count == 0;

    public void Push(T item)
    {
        if (Count == _items.Length)
            Array.Resize(ref _items, _items.Length * 2);

        _items[Count++] = item;
    }

    public T Pop()
    {
        T item = Peek();
        _items[--Count] = default!; // освобождаем ссылку
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Стек пуст!");

        return _items[Count - 1];
    }
}

// Кольцевой буфер: head указывает на первый элемент, место для нового = (head + count) % длина
public class MyQueue<T>
{
    private const int InitialCapacity = 4;
    private T[] _items = new T[InitialCapacity];
    private int _head;

    public int Count { get; private set; }

    public bool IsEmpty() => Count == 0;

    public void Enqueue(T item)
    {
        if (Count == _items.Length)
            Grow();

        _items[(_head + Count) % _items.Length] = item;
        Count++;
    }

    public T Dequeue()
    {
        T item = Peek();
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        Count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Очередь пуста!");

        return _items[_head];
    }

    private void Grow()
    {
        var newItems = new T[_items.Length * 2];

        for (int i = 0; i < Count; i++)
            newItems[i] = _items[(_head + i) % _items.Length];

        _items = newItems;
        _head = 0;
    }
}
