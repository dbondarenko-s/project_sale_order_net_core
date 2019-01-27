using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ciam.Models
{
    public class SalesOrderViewModel
    {
        public SalesOrderViewModel()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetailViewModel>();
        }

        public int? Id { get; set; }

        [Display(Name = "Дата заказа")]
        [Required(ErrorMessage = "Обязательное поле")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Статус заказа")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int? StatusId { get; set; }

        [Display(Name = "Наименование клиента")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int? CustomerId { get; set; }

        [Display(Name = "Комментарий")]
        [MaxLength(2000, ErrorMessage = "Максимальная длина поля \"{0}\" равна {1} символов")]
        public string Comment { get; set; }

        public virtual ICollection<SalesOrderDetailViewModel> SalesOrderDetails { get; set; }

        public virtual SalesStatusViewModel SalesStatus { get; set; }

        public virtual CustomerViewModel Customer { get; set; }
    }
}
