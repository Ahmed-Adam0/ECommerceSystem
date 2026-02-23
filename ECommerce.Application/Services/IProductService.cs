using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.Domain.Entities;

namespace ECommerce.ApplicationLayer.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
         ProductDto GetProductById(int id);
        void CreateProduct(CreateProductDto dto);
        void UpdateProduct(UpdateProductDto dto);
        void DeleteProduct(int id);
        Task SaveChangesAsync();
    }
}
