using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.Services;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                MessageBox.Show("Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (!decimal.TryParse(textBox2.Text.Trim(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Price must be a valid positive number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (!int.TryParse(textBox3.Text.Trim(), out int stock) || stock < 0)
            {
                MessageBox.Show("Stock must be a valid non-negative number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _productService.CreateProduct(new CreateProductDto
            {
                Name = textBox1.Text.Trim(),
                Price = price,
                Stock = stock,
                Description = textBox4.Text.Trim(),
                ImageUrl = textBox5.Text.Trim(),
                CategoryId = (int)comboBox1.SelectedValue
            });

            MessageBox.Show("Product added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}