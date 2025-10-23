using System;
using System.Collections.Generic;

public class Stack<T> where T : IComparable<T>
{
    private List<T> items = new List<T>();

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Стек пуст");

        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Стек пуст");

        return items[items.Count - 1];
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public int Count
    {
        get { return items.Count; }
    }
    public T Max()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Стек пуст");

        T max = items[0];
        foreach (T item in items)
        {
            if (item.CompareTo(max) > 0)
                max = item;
        }
        return max;
    }

    public void PrintStack()
    {
        Console.Write("Стек: ");
        for (int i = items.Count - 1; i >= 0; i--)
        {
            Console.Write(items[i] + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Тестирование обобщенного класса Stack<T> ===");
        Console.WriteLine("\n1. Stack<int>:");
        Stack<int> intStack = new Stack<int>();
        intStack.Push(10);
        intStack.Push(5);
        intStack.Push(20);
        intStack.Push(15);
        intStack.Push(8);

        intStack.PrintStack();
        Console.WriteLine($"Максимальный элемент: {intStack.Max()}");
        Console.WriteLine($"Количество элементов: {intStack.Count}");
        Console.WriteLine($"Извлеченный элемент: {intStack.Pop()}");
        intStack.PrintStack();
        Console.WriteLine($"Максимальный элемент после извлечения: {intStack.Max()}");
        Console.WriteLine("\n2. Stack<double>:");
        Stack<double> doubleStack = new Stack<double>();

        doubleStack.Push(3.14);
        doubleStack.Push(2.71);
        doubleStack.Push(1.618);
        doubleStack.Push(4.669);

        doubleStack.PrintStack();
        Console.WriteLine($"Максимальный элемент: {doubleStack.Max()}");
        Console.WriteLine("\n3. Stack<string>:");
        Stack<string> stringStack = new Stack<string>();

        stringStack.Push("яблоко");
        stringStack.Push("банан");
        stringStack.Push("апельсин");
        stringStack.Push("виноград");

        stringStack.PrintStack();
        Console.WriteLine($"Максимальный элемент: {stringStack.Max()}");
        Console.WriteLine("\n4. Тестирование исключений:");
        Stack<int> emptyStack = new Stack<int>();

        try
        {
            emptyStack.Max();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            emptyStack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}