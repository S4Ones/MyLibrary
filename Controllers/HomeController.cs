using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;
using System.Diagnostics;

namespace MyLibrary.Controllers
{
    /// <summary>
    /// Контроллер для обработки запросов домашней страницы и ошибок.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Обрабатывает запросы для домашней страницы и перенаправляет на список книг.
        /// </summary>
        /// <returns>Редирект на список книг.</returns>
        public IActionResult Index()
        {
            return RedirectToAction("List", "Book");
        }

        /// <summary>
        /// Отображает страницу конфиденциальности.
        /// </summary>
        /// <returns>Представление страницы конфиденциальности.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Отображает страницу ошибки с учетом кэширования.
        /// </summary>
        /// <returns>Представление страницы ошибки.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}