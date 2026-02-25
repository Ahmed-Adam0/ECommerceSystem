using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product, int> _productRepo;

        public ProductService(IGenericRepository<Product, int> productRepo)
        {
            _productRepo = productRepo;
        }


        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _productRepo.GetAll()
                .AsNoTracking()
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Where(p => p.Stock > 0) // 👈 فقط المنتجات المتوفرة
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    MainImageUrl = p.ImageUrl,
                    ImageUrls = p.Images.OrderBy(i => i.Id).Select(i => i.ImageUrl).Take(1).ToList()
                })
                .ToListAsync();
        }
        public List<ProductDto> GetAllProducts()
        {
            return _productRepo.GetAll()
                .AsNoTracking()
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    MainImageUrl = p.ImageUrl,
                    ImageUrls = p.Images.OrderBy(i => i.Id).Select(i => i.ImageUrl).Take(1).ToList()
                })
                .ToList();
        }
        public ProductDto GetProductById(int id)
        {
            var product = _productRepo.GetAll()
                .OfType<Product>()
                .Include(p => p.Images)
                 .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description=product.Description,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                MainImageUrl =product.ImageUrl,
                ImageUrls = product.Images
                .OrderBy(i => i.Id)
                .Select(i => i.ImageUrl)
                .ToList()

            };
        }

        public void CreateProduct(CreateProductDto dto)
        {
            var entity = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Stock = dto.Stock,
                ImageUrl = dto.ImageUrl
            };
            _productRepo.Add(entity);
        }

        public void UpdateProduct(UpdateProductDto dto)
        {
            var entity = _productRepo.GetAll().FirstOrDefault(x => x.Id == dto.Id);
            if (entity == null) return;

            entity.Name = dto.Name;
            entity.Price = dto.Price;
            entity.Description = dto.Description;
            entity.CategoryId = dto.CategoryId;
            entity.Stock = dto.Stock;
            entity.ImageUrl = dto.ImageUrl;
            _productRepo.Update(entity);
        }

        public void DeleteProduct(int id)
        {
            var entity = _productRepo.GetAll().FirstOrDefault(x => x.Id == id);
            if (entity != null)
                _productRepo.Delete(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _productRepo.SaveChangesAsync();
        }
    }
}
