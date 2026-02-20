using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.Domain.Entities;

namespace ECommerce.ApplicationLayer.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategories();
        void CreateCategory(CreateCategoryDto createCategory);
        void UpdateCategory(UpdateCategoryDto updateCategory);
        void DeleteCategory(int id);
    }
}
