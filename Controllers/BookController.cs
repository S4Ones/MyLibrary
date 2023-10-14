using Microsoft.AspNetCore.Mvc;
using MyLibrary.Interfaces;
using MyLibrary.Models;
using MyLibrary.ViewModels;

namespace MyLibrary.Controllers
{
    /// <summary>
    /// Контроллер для управления книгами в библиотеке.
    /// </summary>
    public class BookController : Controller
    {
        private readonly IAllBooks allBooks;
        private readonly IBookGenre bookGenre;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="allBooks">Сервис для работы с книгами.</param>
        /// <param name="bookGenre">Сервис для работы с жанрами книг.</param>
        public BookController(IAllBooks allBooks, IBookGenre bookGenre)
        {
            this.allBooks = allBooks;
            this.bookGenre = bookGenre;
        }

        /// <summary>
        /// Отображает список книг в зависимости от выбранного жанра.
        /// </summary>
        /// <param name="genre">Выбранный жанр книги (по умолчанию пусто).</param>
        /// <returns>Представление списка книг.</returns>
        [Route("Book/List")]
        [Route("Book/List/{genre}")]
        public ViewResult List(string genre)
        {
            string genreNow = genre;
            IEnumerable<Book> books = null;
            IEnumerable<Genre> genres = bookGenre.AllGenres;
            string currGenre = "";
            if (string.IsNullOrEmpty(genre))
            {
                books = allBooks.Books.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("Fantasy", genre, StringComparison.OrdinalIgnoreCase))
                {
                    books = allBooks.Books.Where(i => i.Genre.NameGanre.Equals("Фэнтези")).OrderBy(i => i.Id);
                    currGenre = "Фэнтези";
                }
                else
                {
                    if (string.Equals("Detectives", genre, StringComparison.OrdinalIgnoreCase))
                    {
                        books = allBooks.Books.Where(i => i.Genre.NameGanre.Equals("Детективы")).OrderBy(i => i.Id);
                        currGenre = "Детективы";
                    }
                    else
                    {
                        if (string.Equals("Horror", genre, StringComparison.OrdinalIgnoreCase))
                        {
                            books = allBooks.Books.Where(i => i.Genre.NameGanre.Equals("Ужасы")).OrderBy(i => i.Id);
                            currGenre = "Ужасы";
                        }
                        else
                        {
                            if (string.Equals("Adventures", genre, StringComparison.OrdinalIgnoreCase))
                            {
                                books = allBooks.Books.Where(i => i.Genre.NameGanre.Equals("Приключения")).OrderBy(i => i.Id);
                                currGenre = "Приключения";
                            }
                            else
                            {

                                if (string.Equals("Fantastic", genre, StringComparison.OrdinalIgnoreCase))
                                {
                                    books = allBooks.Books.Where(i => i.Genre.NameGanre.Equals("Фантастика")).OrderBy(i => i.Id);
                                    currGenre = "Фантастика";
                                }
                                else
                                {
                                    if (string.Equals("Novel", genre, StringComparison.OrdinalIgnoreCase))
                                    {
                                        books = allBooks.Books.Where(i => i.Genre.NameGanre.Equals("Роман")).OrderBy(i => i.Id);
                                        currGenre = "Роман";
                                    }
                                    else
                                    {
                                        if (string.Equals("Prose", genre, StringComparison.OrdinalIgnoreCase))
                                        {
                                            books = allBooks.Books.Where(i => i.Genre.NameGanre.Equals("Проза")).OrderBy(i => i.Id);
                                            currGenre = "Проза";
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }

            var perfumeObj = new BookViewModel
            {
                allBooks = books,
                currGenre = currGenre
            };

            ViewBag.Genre = bookGenre.AllGenres;
            ViewBag.Title = "Страница с книгами";
            return View(perfumeObj);
        }
    }
}
