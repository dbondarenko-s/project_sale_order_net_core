using System;
using System.ComponentModel.DataAnnotations;

namespace Ciam.Models
{
    public class SalesOrderDetailViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Заказ")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int? SalesOrderId { get; set; }

        [Display(Name = "Наименование продукта")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int? ProductId { get; set; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int? OrderQty { get; set; }

        [Display(Name = "Цена по прайсу на момент формирования заказа")]
        [Required(ErrorMessage = "Обязательное поле")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Дата изменения")]
        [Required(ErrorMessage = "Обязательное поле")]
        public DateTime? ModifyDate { get; set; }

        public virtual SalesOrderViewModel SalesOrder { get; set; }

        public virtual ProductViewModel Product { get; set; }
    }
}
