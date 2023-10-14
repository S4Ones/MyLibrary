namespace MyLibrary.Models
{
    /// <summary>
    /// Представляет отношение между пользователем и книгой в системе.
    /// </summary>
    public class UserBook
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Пользователь, связанный с данной записью.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Идентификатор книги.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Книга, связанная с данной записью.
        /// </summary>
        public Book Book { get; set; }
    }
}
