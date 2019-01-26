using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciam.DAL.Entities
{
    /// <summary>
    /// Таблица "Позиции в заказе".
    /// </summary>
    [Table("SalesOrderDetail", Schema = "dbo")]
    public class SalesOrderDetail
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key, Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        [Column("SalesOrderId")]
        public int SalesOrderId { get; set; }

        /// <summary>
        /// Идентфикатор продукта.
        /// </summary>
        [Column("ProductId")]
        public int ProductId { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        [Column("OrderQty")]
        public int OrderQty { get; set; }

        /// <summary>
        /// Цена по прайсу на момент формирования заказа.
        /// </summary>
        [Column("UnitPrice")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Дата изменения.
        /// </summary>
        [Column("ModifyDate")]
        public DateTime ModifyDate { get; set; }

        public virtual SalesOrder SalesOrder { get; set; }

        public virtual Product Product { get; set; }
    }
}
