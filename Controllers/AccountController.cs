using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Models;
using MyLibrary.ViewModel;

namespace MyLibrary.Controllers
{
    /// <summary>
    /// Контроллер для управления учетными записями пользователей.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="userManager">Менеджер пользователей для управления пользователями в системе.</param>
        /// <param name="signInManager">Менеджер входа в систему для управления процессом входа и выхода из системы.</param>
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Отображает форму регистрации.
        /// </summary>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Обрабатывает данные из формы регистрации и создает нового пользователя в системе.
        /// </summary>
        /// <param name="model">Модель представления с данными для регистрации.</param>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            User user = new User { Email = model.Email, UserName = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("List", "Book");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        /// <summary>
        /// Отображает форму входа.
        /// </summary>
        /// <param name="returnUrl">URL, на который пользователь будет перенаправлен после успешного входа.</param>
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        /// <summary>
        /// Обрабатывает данные из формы входа и выполняет процесс аутентификации пользователя.
        /// </summary>
        /// <param name="model">Модель представления с данными для входа.</param>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                // проверяем, принадлежит ли URL приложению
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("List", "Book");
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
            return View(model);
        }

        /// <summary>
        /// Выход пользователя из системы.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("List", "Book");
        }
    }
}
