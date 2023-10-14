using Microsoft.AspNetCore.Identity;

namespace MyLibrary.Models
{
    /// <summary>
    /// Представляет пользователя в системе.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Список книг, которые принадлежат пользователю.
        /// </summary>
        public List<UserBook> UserBooks { get; set; }

        /// <summary>
        /// Список отзывов, написанных пользователем.
        /// </summary>
        public List<Review> Reviews { get; set; }
    }

}
