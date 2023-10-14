namespace MyLibrary.Models
{
    /// <summary>
    /// Представляет книгу в библиотеке.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Уникальный идентификатор книги.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Автор книги.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Год публикации книги.
        /// </summary>
        public int YearPublishing { get; set; }

        /// <summary>
        /// Издательство, выпустившее книгу.
        /// </summary>
        public string PublishingHouse { get; set; }

        /// <summary>
        /// Описание содержания книги.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL изображения обложки книги.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// URL книги для чтения.
        /// </summary>
        public string UrlBook { get; set; }

        /// <summary>
        /// Жанр, к которому относится книга.
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// Список отзывов о книге.
        /// </summary>
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
