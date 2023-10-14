using MyLibrary.Context;
using MyLibrary.Interfaces;
using MyLibrary.Models;

namespace Library.Repository
{
    /// <summary>
    /// Реализация интерфейса для работы с жанрами книг в библиотеке.
    /// </summary>
    public class GenreRepository : IBookGenre
    {
        private readonly LibraryContext bookContext;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="bookContext">Контекст базы данных библиотеки.</param>
        public GenreRepository(LibraryContext bookContext)
        {
            this.bookContext = bookContext;
        }

        /// <summary>
        /// Получает коллекцию всех доступных жанров книг в библиотеке.
        /// </summary>
        public IEnumerable<Genre> AllGenres => bookContext.Genres;
    }

}
