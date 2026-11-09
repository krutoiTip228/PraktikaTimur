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
        var account = new BankAccount("Кирилл", 1000m);
        Console.WriteLine($"Счёт открыт. Владелец: {account.OwnerName}, баланс: {account.Balance} руб.\n");

        account.Deposit(500m);
        Console.WriteLine($"После пополнения на 500: баланс = {account.Balance} руб.");

        TryWithdraw(account, 1200m);
        TryWithdraw(account, 5000m);
    }

    private static void TryWithdraw(BankAccount account, decimal amount)
    {
        Console.WriteLine($"\nПытаемся снять {amount} руб...");

        try
        {
            account.Withdraw(amount);
            Console.WriteLine($"Успешно. Новый баланс: {account.Balance} руб.");
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"ОШИБКА: {ex.Message}");
            Console.WriteLine($"Баланс остался: {account.Balance} руб.");
        }
    }
}

public class BankAccount
{
    public string OwnerName { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string ownerName, decimal initialBalance)
    {
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма пополнения должна быть больше нуля.", nameof(amount));

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма снятия должна быть больше нуля.", nameof(amount));

        if (amount > Balance)
            throw new InsufficientFundsException(Balance, amount);

        Balance -= amount;
    }
}

public class InsufficientFundsException : Exception
{
    public decimal CurrentBalance { get; }
    public decimal RequestedAmount { get; }

    public InsufficientFundsException(decimal balance, decimal requested)
        : base($"Недостаточно средств. На счёте: {balance} руб., запрошено: {requested} руб.")
    {
        CurrentBalance = balance;
        RequestedAmount = requested;
    }
}
