using System.ComponentModel.DataAnnotations;

namespace Ciam.Models
{
    public class SalesStatusViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(2000, ErrorMessage = "Максимальная длина поля \"{0}\" равна {1} символов")]
        public string Name { get; set; }
    }
}
