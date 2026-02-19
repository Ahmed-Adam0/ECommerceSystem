using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.DTOs.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
