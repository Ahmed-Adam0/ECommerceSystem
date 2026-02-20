using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.Domain.Entities;

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
          
            var categories = _categoryRepo.GetAll().ToList();

            
            var dtoList = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name

            }).ToList();

            return dtoList;
        }

        public void CreateCategory(CreateCategoryDto createCategory)
        {
            var entity = new Category() { Name = createCategory.Name };
            _categoryRepo.Add(entity);
        }

        public void UpdateCategory(UpdateCategoryDto updateCategory)
        {
            var entity = new Category()
            {
                Id = updateCategory.Id,
                Name = updateCategory.Name
            };
            _categoryRepo.Update(entity);
        }

        public void DeleteCategory(int id)
        {
            var entity = _categoryRepo.GetAll().FirstOrDefault(x => x.Id == id);
            if (entity != null)
                _categoryRepo.Delete(entity);
        }
    }
}
