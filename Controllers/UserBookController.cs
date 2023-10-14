using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Context;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    /// <summary>
    /// Контроллер для управления книгами, добавленными пользователями в их список "Мои книги".
    /// </summary>
    [Authorize]
    public class UserBookController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly LibraryContext libraryContext;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="userManager">Менеджер пользователей.</param>
        /// <param name="libraryContext">Контекст базы данных библиотеки.</param>
        public UserBookController(UserManager<User> userManager, LibraryContext libraryContext)
        {
            this.userManager = userManager;
            this.libraryContext = libraryContext;
        }

        /// <summary>
        /// Отображает список книг, добавленных текущим пользователем в их список "Мои книги".
        /// </summary>
        /// <returns>Представление со списком книг пользователя.</returns>
        public async Task<IActionResult> MyBook()
        {
            var user = await userManager.GetUserAsync(User);
            var books = await libraryContext.UserBooks.Where(b => b.UserId == user.Id).Include(b => b.Book).ToListAsync();

            return View(books);
        }

        /// <summary>
        /// Добавляет выбранную книгу в список "Мои книги" текущего пользователя.
        /// </summary>
        /// <param name="id">Идентификатор книги, которую нужно добавить в список "Мои книги".</param>
        /// <returns>Перенаправление на страницу со списком "Мои книги" после успешного добавления.</returns>
        public async Task<IActionResult> AddToUserBook(int id)
        {
            User user = await userManager.GetUserAsync(User);
            Book selectedBook = await libraryContext.Books.SingleOrDefaultAsync(b => b.Id == id);

            if (selectedBook != null)
            {
                var userBook = new UserBook
                {
                    UserId = user.Id,
                    BookId = selectedBook.Id,
                };

                libraryContext.UserBooks.Add(userBook);
                await libraryContext.SaveChangesAsync();
                return RedirectToAction("MyBook");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
