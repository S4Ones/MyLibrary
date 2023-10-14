namespace MyLibrary.Models
{
    /// <summary>
    /// Представляет отзыв о книге в библиотеке.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Уникальный идентификатор отзыва.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текстовый комментарий в отзыве.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Идентификатор пользователя, оставившего отзыв.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Пользователь, оставивший отзыв.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Уникальный идентификатор книги, к которой относится отзыв.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Книга, к которой относится отзыв.
        /// </summary>
        public Book Book { get; set; }
    }
}
