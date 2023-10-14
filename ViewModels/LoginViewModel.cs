using System.ComponentModel.DataAnnotations;

namespace MyLibrary.ViewModel
{
    /// <summary>
    /// Модель представления для входа в систему.
    /// </summary>
    public class LoginViewModel
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
        /// Получает или задает значение, указывающее, нужно ли запомнить пользователя.
        /// </summary>
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Получает или задает URL, на который пользователь будет перенаправлен после успешного входа.
        /// </summary>
        public string ReturnUrl { get; set; }
    }

}
