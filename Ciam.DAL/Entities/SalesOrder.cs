using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciam.DAL.Entities
{
    /// <summary>
    /// Таблица "Заказы".
    /// </summary>
    [Table("SalesOrder", Schema = "dbo")]
    public class SalesOrder
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key, Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Дата заказа.
        /// </summary>
        [Column("OrderDate")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Статус заказа.
        /// </summary>
        [Column("StatusId")]
        public int StatusId { get; set; }

        /// <summary>
        /// Идентификатор клиента.
        /// </summary>
        [Column("CustomerId")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [Column("Comment")]
        public string Comment { get; set; }

        [ForeignKey("StatusId")]
        public virtual SalesStatus SalesStatus { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
