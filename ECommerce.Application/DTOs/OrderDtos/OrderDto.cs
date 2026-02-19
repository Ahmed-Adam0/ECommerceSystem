using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.OrderitemDtos;

namespace ECommerce.ApplicationLayer.DTOs.OrderDtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
