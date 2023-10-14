using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Context;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    /// <summary>
    /// Контроллер для управления книгами в базе данных (CRUD операции).
    /// </summary>
    public class CRUDController : Controller
    {
        private readonly LibraryContext bookContext;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="bookContext">Контекст базы данных библиотеки.</param>
        public CRUDController(LibraryContext bookContext)
        {
            this.bookContext = bookContext;
        }

        /// <summary>
        /// Отображает страницу CRUD существующих книг.
        /// </summary>
        [Authorize]
        public async Task<IActionResult> Crud()
        {
            ViewBag.Books = await bookContext.Books.ToListAsync();
            return View();
        }

        /// <summary>
        /// Отображает форму создания новой книги.
        /// </summary>
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Обрабатывает данные из формы создания книги и добавляет новую книгу в базу данных.
        /// </summary>
        /// <param name="book">Данные новой книги.</param>
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create(Book book)
        {
            Book newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                YearPublishing = book.YearPublishing,
                PublishingHouse = book.PublishingHouse,
                Description = book.Description,
                Image = book.Image,
                UrlBook = book.UrlBook,
                Genre = book.Genre,

            };
            bookContext.Books.Add(newBook);
            await bookContext.SaveChangesAsync();
            return RedirectToAction("List", "Book");
        }

        /// <summary>
        /// Отображает форму подтверждения удаления книги.
        /// </summary>
        /// <param name="id">Идентификатор книги, которую нужно удалить.</param>
        [Authorize]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfDelete(int id)
        {
            if (id != null)
            {
                Book book = await bookContext.Books.SingleOrDefaultAsync(b => b.Id == id);
                if (book != null)
                    return View(book);
            }
            return NotFound();
        }

        /// <summary>
        /// Удаляет книгу из базы данных.
        /// </summary>
        /// <param name="id">Идентификатор книги, которую нужно удалить.</param>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                Book book = await bookContext.Books.SingleOrDefaultAsync(b => b.Id == id);
                if (book != null)
                {
                    bookContext.Remove(book);
                    await bookContext.SaveChangesAsync();
                    return RedirectToAction("Crud");
                }
            }
            return NotFound();
        }

        /// <summary>
        /// Отображает форму изменения книги.
        /// </summary>
        /// <param name="id">Идентификатор книги, которую нужно изменить.</param>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id != null)
            {
                Book book = await bookContext.Books.SingleOrDefaultAsync(b => b.Id == id);
                if (book != null)
                    return View(book);
            }
            return NotFound();
        }

        /// <summary>
        /// Обрабатывает данные из формы редактирования книги и обновляет книгу в базе данных.
        /// </summary>
        /// <param name="book">Данные книги, которые нужно обновить в базе данных.</param>
        /// <returns>Перенаправление на страницу CRUD после успешного обновления.</returns>

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(Book book)
        {
            bookContext.Books.Update(book);
            await bookContext.SaveChangesAsync();
            return RedirectToAction("Crud");
        }

        /// <summary>
        /// Отображает подробные сведения о книге с заданным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор книги, для которой нужно отобразить подробности.</param>
        /// <returns>Представление с подробными сведениями о книге.</returns>
        public async Task<IActionResult> Deteils(int id)
        {
            if (id != null)
            {
                Book book = bookContext.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);
                ViewBag.thisGenre = book.Genre.NameGanre;
                if (book != null)
                    return View(book);
            }
            return NotFound();
        }

        /// <summary>
        /// Отображает PDF-файл из базы данных.
        /// </summary>
        /// <param name="filePath">Путь к PDF-файлу в базе данных.</param>
        public ActionResult OpenPdfFromDb(string filePath)
        {
            string decodedFilePath = Uri.UnescapeDataString(filePath);

            var pdfFile = bookContext.Books.FirstOrDefault(f => f.UrlBook == decodedFilePath);

            if (pdfFile != null && pdfFile.UrlBook != null && pdfFile.UrlBook.Length > 0)
            {
                Response.ContentType = "application/pdf";
                string fileName = Path.GetFileName(decodedFilePath);
                Response.Headers["Content-Disposition"] = $"inline; filename={fileName}";
                return File(pdfFile.UrlBook, "application/pdf");
            }
            else
            {
                return Content("Файл не найден");
            }
        }
    }
}
