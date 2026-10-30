using System;
using System.Collections.Generic;
using System.Linq;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    public class BookAlreadyBorrowedException : Exception
    {
        public BookAlreadyBorrowedException(string message) : base(message) { }
    }

    public class BorrowLimitExceededException : Exception
    {
        public BorrowLimitExceededException(string message) : base(message) { }
    }


    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    public class Reader
    {
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();

        public Reader(string name)
        {
            Name = name;
        }
    }

    public class Library
    {
        private const int MaxBooksPerReader = 3;

        public void BorrowBook(Reader reader, Book book)
        {
            if (!book.IsAvailable)
            {
                throw new BookAlreadyBorrowedException($"Книга '{book.Title}' уже выдана.");
            }

            if (reader.BorrowedBooks.Count >= MaxBooksPerReader)
            {
                throw new BorrowLimitExceededException($"Читатель '{reader.Name}' достиг лимита в {MaxBooksPerReader} книги.");
            }

            book.IsAvailable = false;
            reader.BorrowedBooks.Add(book);
        }

        public void ReturnBook(Reader reader, Book book)
        {
            if (reader.BorrowedBooks.Contains(book))
            {
                reader.BorrowedBooks.Remove(book);
                book.IsAvailable = true;
            }
        }
    }

    public class Task45_Library : ITask
    {
        public string Title => "Мини-проект «Библиотека» + юнит-тесты";
        public string Description => "Классы библиотеки + тесты (xUnit/NUnit).";

        public string[] Requirements => new[]
        {
            "Классы: Book (Title, Author, IsAvailable), Reader (Name, BorrowedBooks), Library (выдача/возврат).",
            "Логика: выдача книги читателю, возврат, лимит (не больше 3 книг на читателя).",
            "Обработка: книгу уже выдали, лимит превышен — бросать исключения.",
            "Написать 5+ юнит-тестов на ключевые сценарии."
        };

        public void Run()
        {
            Console.WriteLine("Этот класс содержит логику библиотеки.");
            Console.WriteLine("Юнит-тесты находятся в отдельном проекте Visual_Studio.Tests.");
            Console.WriteLine("Запустите их через меню 'Тест' -> 'Запустить все тесты' (Test -> Run All Tests).");
        }
    }
}
