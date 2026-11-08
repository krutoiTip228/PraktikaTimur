using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task30_BankAccount : ITask
{
    public string Title => "BankAccount + свой Exception";
    public string Description => "Реализовать банковский счёт с собственным исключением.";
    public string[] Requirements => new[]
    {
        "Класс BankAccount с приватным балансом",
        "Методы Deposit(decimal), Withdraw(decimal)",
        "Свой класс InsufficientFundsException : Exception",
        "Withdraw бросает исключение, если сумма больше баланса",
        "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)"
    };

    public void Run()
    {
        BankAccount account = new BankAccount("Кирилл", 1000m);

        Console.WriteLine($"Счет открыт. Владелец: {account.OwnerName}, Баланс: {account.Balance} руб.\n");
        account.Deposit(500m);
        Console.WriteLine($"После пополнения на 500: Баланс = {account.Balance} руб.");

        try
        {
            account.Withdraw(1200m);
            Console.WriteLine($"Успешно снято 1200. Новый баланс: {account.Balance} руб.");
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"ОШИБКА при снятии: {ex.Message}");
        }
        try
        {
            Console.WriteLine("\nПытаемся снять 5000 руб...");
            account.Withdraw(5000m);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"ПОЙМАНО ИСКЛЮЧЕНИЕ: {ex.Message}");
            Console.WriteLine($"Текущий баланс остался: {account.Balance} руб.");
        }
    }
}
public class BankAccount
{
    public string OwnerName { get; private set; }

    public decimal Balance { get; private set; }

    public BankAccount(string ownerName, decimal initialBalance)
    {
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма пополнения должна быть больше нуля.");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма снятия должна быть больше нуля.");

        if (amount > Balance)
        {
            throw new InsufficientFundsException(Balance, amount);
        }

        Balance -= amount;
    }
}
public class InsufficientFundsException : Exception
{
    public decimal CurrentBalance { get; }
    public decimal RequestedAmount { get; }

    public InsufficientFundsException(decimal balance, decimal requested)
        : base($"Недостаточно средств. На счете: {balance} руб., запрошено: {requested} руб.")
    {
        CurrentBalance = balance;
        RequestedAmount = requested;
    }
}