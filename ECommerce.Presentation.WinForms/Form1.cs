using System;
using System.Windows.Forms;
using System.Xml.Linq;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.ApplicationLayer.Services;
using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.Domain.Entities;

namespace ECommerce.Presentation.WinForms
{
    public partial class Form1 : Form
    {
        private readonly ICategoryService _categoryService;

        public Form1(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = _categoryService.GetAllCategories();
            dataGridView1.DataSource = categories;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dto = new CreateCategoryDto()
            {
                Name = textName.Text
            };

            _categoryService.CreateCategory(dto);
            LoadCategories();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var selectedCategory = (Category)dataGridView1.CurrentRow.DataBoundItem;
                var dto = new UpdateCategoryDto()
                {
                    Id = selectedCategory.Id,
                    Name = textName.Text
                };

                _categoryService.UpdateCategory(dto);
                LoadCategories();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var selectedCategory = (Category)dataGridView1.CurrentRow.DataBoundItem;
                _categoryService.DeleteCategory(selectedCategory.Id);
                LoadCategories();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
