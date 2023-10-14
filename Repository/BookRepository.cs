using MyLibrary.Context;
using MyLibrary.Models;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Interfaces;

namespace MyLibrary.Repository
{
    /// <summary>
    /// Реализация интерфейса для работы с книгами в библиотеке.
    /// </summary>
    public class BookRepository : IAllBooks
    {
        private readonly LibraryContext bookContext;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="bookContext">Контекст базы данных библиотеки.</param>
        public BookRepository(LibraryContext bookContext)
        {
            this.bookContext = bookContext;
        }

        /// <summary>
        /// Получает коллекцию всех книг в библиотеке вместе с жанрами.
        /// </summary>
        public IEnumerable<Book> Books => bookContext.Books.Include(g => g.Genre);

        /// <summary>
        /// Получает объект книги по ее идентификатору.
        /// </summary>
        /// <param name="bookID">Идентификатор книги.</param>
        /// <returns>Объект книги, соответствующий указанному идентификатору.</returns>
        public Book getObjectBook(int bookID) => bookContext.Books.FirstOrDefault(b => b.Id == bookID);
    }

}
