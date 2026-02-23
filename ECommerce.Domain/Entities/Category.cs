using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Models;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Category: BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new();
    }
}
