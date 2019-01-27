using System.ComponentModel.DataAnnotations;

namespace Ciam.Models
{
    public class CustomerViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Наименование клиента")]
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(2000, ErrorMessage = "Максимальная длина поля \"{0}\" равна {1} символов")] 
        public string Name { get; set; }
    }
}
