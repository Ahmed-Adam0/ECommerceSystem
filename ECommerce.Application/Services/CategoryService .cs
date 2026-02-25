using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.ApplicationLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category, int> _categoryRepo;

        // Dependency Injection
        public CategoryService(IGenericRepository<Category, int> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public List<CategoryDto> GetAllCategories()
        {

            var dtoList = _categoryRepo.GetAll()
                     .Include(c => c.Products)
                     .Select(c => new CategoryDto
                     {
                         Id = c.Id,
                         Name = c.Name,
                         ImageUrl = c.ImageUrl,
                         ProductCount = c.Products.Count
                     }).ToList();

            return dtoList;
        }

        public void CreateCategory(CreateCategoryDto createCategory)
        {
            var entity = new Category()
            {
                Name = createCategory.Name,
                ImageUrl = createCategory.ImageUrl
            };
            _categoryRepo.Add(entity);
        }

        public void UpdateCategory(UpdateCategoryDto updateCategory)
        {
            var entity = _categoryRepo.GetAll().FirstOrDefault(x => x.Id == updateCategory.Id);
            if (entity != null)
            {
                entity.Name = updateCategory.Name;
                entity.ImageUrl = updateCategory.ImageUrl;
                _categoryRepo.Update(entity);
            }
        }

        public void DeleteCategory(int id)
        {
            var entity = _categoryRepo.GetAll().FirstOrDefault(x => x.Id == id);
            if (entity != null)
                _categoryRepo.Delete(entity);
        }
    }
}
