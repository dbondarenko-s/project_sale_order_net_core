using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciam.DAL.Entities
{
    /// <summary>
    /// Таблица "Статусы заказа".
    /// </summary>
    [Table("SalesStatus", Schema = "dbo")]
    public class SalesStatus
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        [Key, Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Название статуса.
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
    }
}
