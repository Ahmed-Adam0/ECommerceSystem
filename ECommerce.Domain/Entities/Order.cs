using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Enums;
using ECommerce.Domain.Models;

namespace ECommerce.Domain.Entities
{
    public class Order:BaseEntity<int>
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public int UserId { get; set; }
        public User? User { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
