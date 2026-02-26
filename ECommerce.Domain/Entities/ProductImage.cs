using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class ProductImage : BaseEntity<int>
    {
        public string ImageUrl { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}