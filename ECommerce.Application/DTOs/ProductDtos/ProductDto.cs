using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.DTOs.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string MainImageUrl { get; set; }

        public int Stock { get; set; }
        public int CategoryId { get; internal set; }
        public List<string> ImageUrls { get; set; } = new();
    }
}
