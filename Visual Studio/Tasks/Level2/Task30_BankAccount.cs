using System;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{ 
    public class InsufficientFundsException : Exception
    {
        public decimal CurrentBalance { get; }
        public decimal AmountToWithdraw { get; }

        public InsufficientFundsException(decimal balance, decimal amount)
            : base($"Недостаточно средств. Баланс: {balance}, попытка снять: {amount}")
        {
            CurrentBalance = balance;
            AmountToWithdraw = amount;
        }
    }


    public class BankAccount
    {

        private decimal _balance;

        public decimal Balance => _balance; 

        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Начальный баланс не может быть отрицательным.");

            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма пополнения должна быть больше нуля.");

            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма снятия должна быть больше нуля.");


            if (amount > _balance)
            {
                throw new InsufficientFundsException(_balance, amount);
            }

            _balance -= amount;
        }
    }


    public class Task30_BankAccount : ITask
    {
        public string Title => "BankAccount + свой Exception";
        public string Description => "Реализовать банковский счёт с собственным исключением.";

        public string[] Requirements => new[]
        {
            "Класс BankAccount с приватным балансом.",
            "Методы Deposit(decimal), Withdraw(decimal).",
            "Свой класс InsufficientFundsException : Exception.",
            "Withdraw бросает исключение, если сумма больше баланса.",
            "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)."
        };

        public void Run()
        {
            BankAccount account = new BankAccount(1000m);
            Console.WriteLine($"Счет создан. Баланс: {account.Balance} руб.\n");

            try
            {
                Console.WriteLine("Пополняем на 500 руб...");
                account.Deposit(500m);
                Console.WriteLine($"Баланс после пополнения: {account.Balance} руб.");

                Console.WriteLine("\nСнимаем 200 руб...");
                account.Withdraw(200m);
                Console.WriteLine($"Баланс после снятия: {account.Balance} руб.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }


            Console.WriteLine("\n--- Попытка снять 5000 руб. ---");
            try
            {
                account.Withdraw(5000m); 
                Console.WriteLine("Этого сообщения не будет, так как сработал catch.");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"ПОЙМАНО ИСКЛЮЧЕНИЕ: {ex.Message}");
                Console.WriteLine($"Текущий баланс остался: {ex.CurrentBalance} руб.");
                Console.WriteLine($"Сколько пытались снять: {ex.AmountToWithdraw} руб.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Какая-то другая ошибка: {ex.Message}");
            }
        }
    }
}