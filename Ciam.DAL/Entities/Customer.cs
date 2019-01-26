using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciam.DAL.Entities
{
    /// <summary>
    /// Таблица - "Клиенты".
    /// </summary>
    [Table("Customer", Schema = "dbo")]
    public class Customer
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key, Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Наименование клиента.
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
    }
}
