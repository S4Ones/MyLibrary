using System.ComponentModel.DataAnnotations;

namespace MyLibrary.ViewModel
{
    /// <summary>
    /// Модель представления для регистрации нового пользователя.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Получает или задает адрес электронной почты пользователя.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Получает или задает пароль пользователя.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Получает или задает подтверждение пароля пользователя.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }

}
