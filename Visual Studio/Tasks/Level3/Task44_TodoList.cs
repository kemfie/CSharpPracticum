using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    // --- 1. МОДЕЛЬ ---
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public override string ToString()
        {
            string status = IsDone ? "[x]" : "[ ]";
            return $"{status} {Id}. {Title}";
        }
    }

    public class TaskRepository
    {
        private readonly string _filePath;

        public TaskRepository(string filePath = "tasks.json")
        {
            _filePath = filePath;
        }

        public List<TaskItem> Load()
        {
            if (!File.Exists(_filePath))
            {
                return new List<TaskItem>(); 
            }

            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            catch (JsonException)
            {
                Console.WriteLine("Ошибка: Файл tasks.json поврежден. Создан новый список.");
                return new List<TaskItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке: {ex.Message}");
                return new List<TaskItem>();
            }
        }

        public void Save(List<TaskItem> tasks)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(tasks, options);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }
        }
    }

    public class TaskService
    {
        private List<TaskItem> _tasks;
        private readonly TaskRepository _repository;

        public TaskService()
        {
            _repository = new TaskRepository();
            _tasks = _repository.Load();
        }

        public void AddTask(string title)
        {
            int newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(new TaskItem { Id = newId, Title = title, IsDone = false });
            _repository.Save(_tasks);
            Console.WriteLine("Задача добавлена!");
        }

        public void ShowAll()
        {
            if (!_tasks.Any())
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }

            Console.WriteLine("\n--- Ваши задачи ---");
            foreach (var task in _tasks)
            {
                Console.WriteLine(task);
            }
        }

        public void MarkAsDone(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsDone = true;
                _repository.Save(_tasks);
                Console.WriteLine($"Задача {id} отмечена выполненной.");
            }
            else
            {
                Console.WriteLine($"Задача с ID {id} не найдена.");
            }
        }

        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
                _repository.Save(_tasks);
                Console.WriteLine($"Задача {id} удалена.");
            }
            else
            {
                Console.WriteLine($"Задача с ID {id} не найдена.");
            }
        }
    }

    public class Task44_TodoList : ITask
    {
        public string Title => "Мини-проект «Todo List» (классы + JSON)";
        public string Description => "Консольное приложение для списка задач с сохранением в JSON.";

        public string[] Requirements => new[]
        {
            "Классы: TaskItem (Id, Title, IsDone), TaskRepository (CRUD), TaskService (бизнес-логика).",
            "CRUD-операции: добавить, вывести все, отметить выполненной, удалить.",
            "Сохранение/загрузка через System.Text.Json (файл tasks.json).",
            "Меню с выбором действий.",
            "Обработка ошибок (некорректный ввод, отсутствующий файл)."
        };

        public void Run()
        {
            TaskService service = new TaskService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== TODO LIST ===");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Показать все задачи");
                Console.WriteLine("3. Отметить задачу выполненной");
                Console.WriteLine("4. Удалить задачу");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string title = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(title))
                        {
                            service.AddTask(title);
                        }
                        else
                        {
                            Console.WriteLine("Название не может быть пустым!");
                        }
                        break;
                    case "2":
                        service.ShowAll();
                        break;
                    case "3":
                        Console.Write("Введите ID задачи: ");
                        if (int.TryParse(Console.ReadLine(), out int idToMark))
                        {
                            service.MarkAsDone(idToMark);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: ID должно быть числом.");
                        }
                        break;
                    case "4":
                        Console.Write("Введите ID задачи: ");
                        if (int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            service.DeleteTask(idToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: ID должно быть числом.");
                        }
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        break;
                }
            }
        }
    }
}
