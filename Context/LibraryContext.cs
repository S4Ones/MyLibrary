using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyLibrary.Context
{
    /// <summary>
    /// Представляет контекст базы данных для библиотечного приложения.
    /// </summary>
    public class LibraryContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Коллекция книг в базе данных.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Коллекция связей пользователь-книга в базе данных.
        /// </summary>
        public DbSet<UserBook> UserBooks { get; set; }

        /// <summary>
        /// Коллекция отзывов в базе данных.
        /// </summary>
        public DbSet<Review> Reviews { get; set; }

        /// <summary>
        /// Коллекция жанров книг в базе данных.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }


        /// <summary>
        /// Переопределение метода для настройки отношений между сущностями в базе данных.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели базы данных.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBook>()
                .HasKey(ub => new { ub.UserId, ub.BookId });
            modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(e => new { e.LoginProvider, e.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasKey(e => new { e.UserId, e.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

        }

        /// <summary>
        /// Конструктор контекста базы данных библиотеки.
        /// </summary>
        /// <param name="options">Настройки контекста базы данных.</param>
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
