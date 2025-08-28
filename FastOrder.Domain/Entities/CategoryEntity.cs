﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FastOrder.Domain.Entities
{
    [Table("ItemOrder")]
    public class CategoryEntity
    {
        public long  Id { get; set; }
        public string Name { get; set; }
    }
}
