namespace MyLibrary.Models
{
    /// <summary>
    /// Жанры.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Уникальный идентификатор жанра.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название жанра.
        /// </summary>
        public string NameGanre { get; set; }

        /// <summary>
        /// Списаок книг в определенным жанром.
        /// </summary>
        public List<Book> books { get; set; }
    }
}
