using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ciam.DAL.Entities
{
    /// <summary>
    /// Таблица "Продукты".
    /// </summary>
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key, Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Наименование продукта.
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Цена продукта.
        /// </summary>
        [Column("ListPrice")]
        public decimal ListPrice { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        [Column("Comment")]
        public string Comment { get; set; }
    }
}
