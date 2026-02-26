using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Entities
{
    public class OrderItem: BaseEntity<int>
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
