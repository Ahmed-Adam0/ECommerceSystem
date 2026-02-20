using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.Domain.Entities;

namespace ECommerce.ApplicationLayer.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAllProducts();
        void CreateProduct(CreateProductDto dto);
        void UpdateProduct(UpdateProductDto dto);
        void DeleteProduct(int id);
    }
}
