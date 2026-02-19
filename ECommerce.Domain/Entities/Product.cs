using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Models;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Product:BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
        public List<CartItem> CartItems { get; set; } = new();
    }
}
