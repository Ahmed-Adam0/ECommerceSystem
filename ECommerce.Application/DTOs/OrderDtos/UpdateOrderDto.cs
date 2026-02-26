using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Domain.Enums;

namespace ECommerce.ApplicationLayer.DTOs.OrderDtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
