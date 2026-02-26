using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Entities
{
    public class CartItem: BaseEntity<int>
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }

        public bool IsOrdered { get; set; }
    }
}
