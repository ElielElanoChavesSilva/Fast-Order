using System.ComponentModel.DataAnnotations.Schema;

namespace FastOrder.Domain.Entities
{
    [Table("Category")]
    public class CategoryEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
