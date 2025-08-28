using System.ComponentModel.DataAnnotations.Schema;

namespace FastOrder.Domain.Entities
{
    [Table("Orders")]
    public class OrderEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public decimal TotalPrice { get; set; }
        public ClientEntity ClientEntity { get; set; }
    }
}
