using System.ComponentModel.DataAnnotations.Schema;

namespace FastOrder.Domain.Entities
{
    [Table("Client")]
    public class ClientEntity 
    {
        public long Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;

    }
}
