using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.DTOs.CartItemDtos
{
    public class CartItemDto
    {
        public int Id { get; set; } // Id الخاص بالـ CartItem نفسه
        public int ProductId { get; set; }
        public string ProductName { get; set; } // لو عايز تعرض الاسم
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; internal set; }
        public bool IsOrdered { get; internal set; }
    }
}
