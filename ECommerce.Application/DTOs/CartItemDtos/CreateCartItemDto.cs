using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.DTOs.CartItemDtos
{
    public class CreateCartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
