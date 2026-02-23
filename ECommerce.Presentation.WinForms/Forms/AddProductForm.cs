using System;
using System.Windows.Forms;
using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.Services;

namespace ECommerce.Presentation.WinForms.Forms
{
    public partial class AddProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public AddProductForm(IProductService productService, ICategoryService categoryService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            
            comboBox1.DataSource = _categoryService.GetAllCategories();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Name is required.");
                return;
            }

            
            if (!decimal.TryParse(textBox2.Text.Trim(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Price must be a valid positive number.");
                return;
            }

            
            if (!int.TryParse(textBox3.Text.Trim(), out int stock) || stock < 0)
            {
                MessageBox.Show("Stock must be a valid non-negative number.");
                return;
            }

            
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            var dto = new CreateProductDto
            {
                Name = textBox1.Text.Trim(),
                Price = price,
                Description = textBox4.Text.Trim(),
                Stock = stock,
                CategoryId = (int)comboBox1.SelectedValue
            };

            _productService.CreateProduct(dto);
            MessageBox.Show("Product added successfully!");
            this.Close();
        }
    }
}