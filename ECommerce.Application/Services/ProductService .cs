using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;

namespace ECommerce.ApplicationLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product, int> _productRepo;

        public ProductService(IGenericRepository<Product, int> productRepo)
        {
            _productRepo = productRepo;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAll().ToList();
        }

        public void CreateProduct(CreateProductDto dto)
        {
            var entity = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CategoryId = dto.CategoryId
            };
            _productRepo.Add(entity);
        }

        public void UpdateProduct(UpdateProductDto dto)
        {
            var entity = new Product()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CategoryId = dto.CategoryId
            };
            _productRepo.Update(entity);
        }

        public void DeleteProduct(int id)
        {
            var entity = _productRepo.GetAll().FirstOrDefault(x => x.Id == id);
            if (entity != null)
                _productRepo.Delete(entity);
        }
    }
}
