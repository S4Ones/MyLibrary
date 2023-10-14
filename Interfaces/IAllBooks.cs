using MyLibrary.Models;

namespace MyLibrary.Interfaces
{
    /// <summary>
    /// Интерфейс, представляющий операции для работы с книгами в библиотеке.
    /// </summary>
    public interface IAllBooks
    {
        /// <summary>
        /// Получает коллекцию всех книг в библиотеке.
        /// </summary>
        IEnumerable<Book> Books { get; }

        /// <summary>
        /// Получает объект книги по ее идентификатору.
        /// </summary>
        /// <param name="bookID">Идентификатор книги.</param>
        /// <returns>Объект книги, соответствующий указанному идентификатору.</returns>
        Book getObjectBook(int bookID);
    }
}
