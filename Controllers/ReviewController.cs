using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Context;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    /// <summary>
    /// Контроллер для управления отзывами о книгах.
    /// </summary>
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly LibraryContext libraryContext;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="userManager">Менеджер пользователей.</param>
        /// <param name="libraryContext">Контекст базы данных библиотеки.</param>
        public ReviewController(UserManager<User> userManager, LibraryContext libraryContext)
        {
            this.userManager = userManager;
            this.libraryContext = libraryContext;
        }

        /// <summary>
        /// Отображает отзывы о книге с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор книги, для которой нужно отобразить отзывы.</param>
        /// <returns>Представление с отзывами о книге.</returns>
        public async Task<IActionResult> ShowReview(int id)
        {
            var reviews = await libraryContext.Reviews.Where(r => r.BookId == id).ToListAsync();
            ViewBag.Book = libraryContext.Books.SingleOrDefault(b => b.Id == id);
            ViewBag.User = await userManager.GetUserAsync(User);
            return View(reviews);
        }

        /// <summary>
        /// Отображает форму для добавления нового отзыва о книге с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор книги, для которой нужно добавить отзыв.</param>
        /// <returns>Представление формы добавления отзыва.</returns>
        public async Task<IActionResult> AddReview(int id)
        {
            ViewBag.User = await userManager.GetUserAsync(User);
            ViewBag.Book = libraryContext.Books.SingleOrDefault(b => b.Id == id);
            return View();
        }

        /// <summary>
        /// Обрабатывает данные из формы добавления отзыва и добавляет новый отзыв о книге в базу данных.
        /// </summary>
        /// <param name="review">Данные нового отзыва о книге.</param>
        /// <returns>Перенаправление на страницу с отзывами после успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> AddReview(Review review)
        {
            var newReview = new Review()
            {
                Comment = review.Comment,
                UserId = review.UserId,
                BookId = review.BookId
            };

            libraryContext.Reviews.Add(newReview);
            await libraryContext.SaveChangesAsync();
            return View("ShowReview");
        }
    }
}
