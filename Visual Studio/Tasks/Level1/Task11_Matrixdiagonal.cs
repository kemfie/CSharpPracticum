using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    public class Task11_MatrixDiagonal : ITask
    {
        public string Title => "Диагональ матрицы N×N";
        public string Description => "Найти сумму элементов главной диагонали матрицы N×N.";

        public string[] Requirements => new[]
        {
            "Размер N вводится пользователем (минимум 2).",
            "Матрица заполняется случайными числами.",
            "Сумма считается без LINQ, в одном цикле for.",
            "Вывести саму матрицу и сумму."
        };

        public void Run()
        {
            int n;
            while (true)
            {
                Console.Write("Введите размер матрицы N (минимум 2): ");
                if (int.TryParse(Console.ReadLine(), out n) && n >= 2)
                {
                    break;
                }
                Console.WriteLine("Ошибка! Введите целое число от 2 и больше.");
            }
            int[,] matrix = new int[n, n];
            Random rnd = new Random();

            Console.WriteLine("\nСгенерированная матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(1, 10);
                    Console.Write($"{matrix[i, j],3} ");
                }
                Console.WriteLine();
            }

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }
            Console.WriteLine($"\nСумма элементов главной диагонали: {sum}");
        }
    }
}
