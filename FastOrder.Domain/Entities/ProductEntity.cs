using System.ComponentModel.DataAnnotations.Schema;

namespace FastOrder.Domain.Entities
{
    [Table("Product")]
    public class ProductEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
