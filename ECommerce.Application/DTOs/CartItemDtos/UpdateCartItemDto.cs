using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.DTOs.CartItemDtos
{
    public class UpdateCartItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
