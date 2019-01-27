using System.ComponentModel.DataAnnotations;

namespace Ciam.Models
{
    public class ProductViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(2000, ErrorMessage = "Максимальная длина поля \"{0}\" равна {1} символов")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Обязательное поле")]
        public decimal? ListPrice { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
    }
}
