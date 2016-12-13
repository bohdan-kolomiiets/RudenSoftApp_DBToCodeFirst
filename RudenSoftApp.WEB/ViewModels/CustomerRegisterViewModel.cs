using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RudenSoftApp.WEB.ViewModels
{
    public class CustomerRegisterViewModel
    {
        [Required]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Електронна пошта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 10, ErrorMessage= "{0} має бути хоча б {2} символів в довжину.",MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Паролі не співпадають.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(18,100,ErrorMessage = "Вік не може бути меншим за 18 та більшим за 100")]
        public int? Age { get; set; }

        [Display(Name = "Про себе")]
        [StringLength(maximumLength:1000,ErrorMessage = "{0} має бути хоча б {2} символів в довжину.", MinimumLength = 40)]
        public string AboutMe { get; set; }

        [Required]
        [Display(Name = "Місто")]
        public int DistrictId { get; set; }

    }
}
