using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReenbitDotNetTestTask.Models
{

    public class MainForm
    {
        [Required(ErrorMessage = "Вам необхідно ввести пошту")]
        [Display(Name = "Введіть вашу пошту")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Виберіть файл з розширенням .docx")]
        [Display(Name = "Виберіть файл")]
        public IFormFile File { get; set; }
    }
}

