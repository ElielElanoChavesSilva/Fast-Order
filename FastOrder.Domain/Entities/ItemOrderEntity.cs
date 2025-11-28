using System.ComponentModel.DataAnnotations.Schema;

namespace FastOrder.Domain.Entities
{
    [Table("ItemOrder")]
    public class ItemOrderEntity
    {
        public long Id { get; set; }
        public int QtdProduct { get; set; }
        public long ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public long OrderId { get; set; }
        public OrderEntity Order { get; set; }
        public decimal Price { get; set; }
    }
}
