using System;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
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
        public void Send(string message)
        {
            Console.WriteLine($"[Email] Отправка письма: {message}");
        }
    }

    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[SMS] Отправка сообщения: {message}");
        }
    }

    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[Push] Отправка пуша: {message}");
        }
    }


    public static class NotificationFactory
    {
        public static INotification Create(NotificationType type)
        {

            switch (type)
            {
                case NotificationType.Email:
                    return new EmailNotification();
                case NotificationType.Sms:
                    return new SmsNotification();
                case NotificationType.Push:
                    return new PushNotification();
                default:
                    throw new ArgumentException("Неизвестный тип уведомления", nameof(type));
            }
        }
    }


    public class Task29_Factory : ITask
    {
        public string Title => "Паттерн «Фабрика» (уведомления)";
        public string Description => "Реализовать фабрику уведомлений.";

        public string[] Requirements => new[]
        {
            "Интерфейс INotification с методом Send(string message).",
            "Реализации: EmailNotification, SmsNotification, PushNotification.",
            "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию.",
            "enum NotificationType { Email, Sms, Push }.",
            "Продемонстрировать создание и отправку через фабрику."
        };

        public void Run()
        {
            string text = "Ваш заказ готов!";
            Console.WriteLine($"Текст уведомления: \"{text}\"\n");


            INotification email = NotificationFactory.Create(NotificationType.Email);
            email.Send(text);

            INotification sms = NotificationFactory.Create(NotificationType.Sms);
            sms.Send(text);

            INotification push = NotificationFactory.Create(NotificationType.Push);
            push.Send(text);

        }
    }
}