using System;
using Xunit;
using Visual_Studio.Tasks.Level3;

namespace Visual_Studio.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void BorrowBook_Success()
        {
            // Arrange (Подготовка)
            var library = new Library();
            var book = new Book("Война и мир", "Толстой");
            var reader = new Reader("Иван");

            // Act (Действие)
            library.BorrowBook(reader, book);

            // Assert (Проверка)
            Assert.False(book.IsAvailable); // Книга стала недоступна
            Assert.Single(reader.BorrowedBooks); // У читателя 1 книга
        }

        [Fact]
        public void BorrowBook_AlreadyBorrowed_ThrowsException()
        {
            var library = new Library();
            var book = new Book("1984", "Оруэлл");
            var reader1 = new Reader("Иван");
            var reader2 = new Reader("Петр");

            library.BorrowBook(reader1, book);

            // Проверяем, что при попытке выдать занятую книгу вылетит исключение
            Assert.Throws<BookAlreadyBorrowedException>(() => library.BorrowBook(reader2, book));
        }

        [Fact]
        public void BorrowBook_LimitExceeded_ThrowsException()
        {
            var library = new Library();
            var reader = new Reader("Иван");
            var book1 = new Book("Книга 1", "Автор");
            var book2 = new Book("Книга 2", "Автор");
            var book3 = new Book("Книга 3", "Автор");
            var book4 = new Book("Книга 4", "Автор");

            // Берем 3 книги (лимит)
            library.BorrowBook(reader, book1);
            library.BorrowBook(reader, book2);
            library.BorrowBook(reader, book3);

            // 4-я должна вызвать ошибку
            Assert.Throws<BorrowLimitExceededException>(() => library.BorrowBook(reader, book4));
        }

        [Fact]
        public void ReturnBook_Success()
        {
            var library = new Library();
            var book = new Book("Гарри Поттер", "Роулинг");
            var reader = new Reader("Иван");

            library.BorrowBook(reader, book);
            library.ReturnBook(reader, book);

            Assert.True(book.IsAvailable); // Книга снова доступна
            Assert.Empty(reader.BorrowedBooks); // У читателя 0 книг
        }

        [Fact]
        public void BorrowBook_AfterReturn_Success()
        {
            var library = new Library();
            var book = new Book("Хоббит", "Толкин");
            var reader1 = new Reader("Иван");
            var reader2 = new Reader("Петр");

            library.BorrowBook(reader1, book);
            library.ReturnBook(reader1, book);

            // Теперь Петр должен смочь взять ту же книгу
            library.BorrowBook(reader2, book);

            Assert.False(book.IsAvailable);
            Assert.Single(reader2.BorrowedBooks);
        }
    }
}