using MyLibrary.Models;

namespace MyLibrary.Interfaces
{
    /// <summary>
    /// Интерфейс, представляющий операции для работы с жанрами книг в библиотеке.
    /// </summary>
    public interface IBookGenre
    {
        /// <summary>
        /// Получает коллекцию всех доступных жанров книг в библиотеке.
        /// </summary>
        IEnumerable<Genre> AllGenres { get; }
    }

}
