using MyLibrary.Models;

namespace MyLibrary.ViewModels
{
    /// <summary>
    /// Модель представления для отображения книг в представлении.
    /// </summary>
    public class BookViewModel
    {
        /// <summary>
        /// Получает или задает коллекцию всех книг.
        /// </summary>
        public IEnumerable<Book> allBooks { get; set; }

        /// <summary>
        /// Получает или задает текущий выбранный жанр.
        /// </summary>
        public string currGenre { get; set; }
    }

}
