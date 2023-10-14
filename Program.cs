using Library.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Context;
using MyLibrary.Interfaces;
using MyLibrary.Models;
using MyLibrary.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyLibrary
{
    public class Program
    {
        /// <summary>
        /// Запуск программы.
        /// </summary>
        /// <param name="args">Массив строк, содержащий аргументы командной строки, переданные при запуске программы.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connection));

            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<LibraryContext>().AddDefaultTokenProviders();
            builder.Services.AddTransient<IAllBooks, BookRepository>();
            builder.Services.AddTransient<IBookGenre, GenreRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}