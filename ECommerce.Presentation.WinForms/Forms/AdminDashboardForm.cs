using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Presentation.WinForms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ECommerce.Presentation.WinForms
{
    public partial class AdminDashboardForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private List<CategoryDto> _allCategories = new();
        private List<ProductDto> _allProducts = new();


        public AdminDashboardForm(ICategoryService categoryService, IProductService productService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _productService = productService;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string keyword = textBox2.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
                dataGridView1.DataSource = _allCategories;
            else
                dataGridView1.DataSource = _allCategories
                    .Where(c => c.Name.ToLower().Contains(keyword))
                    .ToList();
        }
        private void LoadCategories()
        {
            _allCategories = _categoryService.GetAllCategories();
            dataGridView1.DataSource = _allCategories;
        }
        private void LoadProducts()
        {
            _allProducts = _productService.GetAllProducts();
            dataGridView2.DataSource = _allProducts;
        }
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Category name is required.");
                return;
            }

            _categoryService.CreateCategory(new CreateCategoryDto { Name = textBox1.Text.Trim() });
            textBox1.Clear();
            LoadCategories();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a category to delete.");
                return;
            }

            if (dataGridView1.CurrentRow.DataBoundItem is not CategoryDto selected) return;

            var confirm = MessageBox.Show("Are you sure you want to delete this category?",
                "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _categoryService.DeleteCategory(selected.Id);
                LoadCategories();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var addForm = new AddProductForm(_productService, _categoryService);
            addForm.ShowDialog();
            LoadProducts();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }

            if (dataGridView2.CurrentRow.DataBoundItem is not ProductDto selected) return;

            var confirm = MessageBox.Show("Are you sure you want to delete this product?",
                "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _productService.DeleteProduct(selected.Id);
                LoadProducts();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string keyword = textBox4.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
                dataGridView2.DataSource = _allProducts;
            else
                dataGridView2.DataSource = _allProducts
                    .Where(p => p.Name.ToLower().Contains(keyword))
                    .ToList();
        }
        private void tabPage2_Click(object sender, EventArgs e) { }

    }
}
