using System;
using CSharpPraktikum.Common;

namespace CSharpPraktikum.Tasks.Level2;

public class Task29_FabricPattern : ITask
{
    public string Title => "Паттерн Фабрика (уведомления)";
    public string Description => "Реализовать фабрику уведомлений (Email, SMS, Push).";
    public string[] Requirements => new[]
    {
        "Интерфейс INotification с методом Send(string message)",
        "Реализации: EmailNotification, SmsNotification, PushNotification",
        "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию",
        "enum NotificationType { Email, Sms, Push }"
    };

    public void Run()
    {
        Console.WriteLine("Тест фабрики уведомлений");

        NotificationFactory.Create(NotificationType.Email).Send("Ваш заказ отправлен");
        NotificationFactory.Create(NotificationType.Sms).Send("Пришёл код подтверждения");
        NotificationFactory.Create(NotificationType.Push).Send("Пришло новое сообщение");
    }
}

public enum NotificationType
{
    Email,
    Sms,
    Push
}

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[EMAIL] Отправлено: {message}");
}

public class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[SMS] Отправлено: {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[PUSH] Отправлено: {message}");
}

public static class NotificationFactory
{
    public static INotification Create(NotificationType type) => type switch
    {
        NotificationType.Email => new EmailNotification(),
        NotificationType.Sms => new SmsNotification(),
        NotificationType.Push => new PushNotification(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Неизвестный тип уведомления")
    };
}
