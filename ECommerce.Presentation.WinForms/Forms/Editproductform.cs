using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.Services;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ECommerce.Presentation.WinForms.Forms
{
    public partial class EditProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ProductDto _existing;

        public EditProductForm(IProductService productService, ICategoryService categoryService, ProductDto existing)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
            _existing = existing;
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {
            // Load categories
            cmbCategory.DataSource = _categoryService.GetAllCategories();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";

            // Prefill fields
            txtName.Text = _existing.Name;
            txtPrice.Text = _existing.Price.ToString();
            txtStock.Text = _existing.Stock.ToString();
            txtDescription.Text = _existing.Description;
            txtImageUrl.Text = _existing.MainImageUrl;
            cmbCategory.SelectedValue = _existing.CategoryId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Price must be a valid positive number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            if (!int.TryParse(txtStock.Text.Trim(), out int stock) || stock < 0)
            {
                MessageBox.Show("Stock must be a valid non-negative number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _productService.UpdateProduct(new UpdateProductDto
            {
                Id = _existing.Id,
                Name = txtName.Text.Trim(),
                Price = price,
                Stock = stock,
                Description = txtDescription.Text.Trim(),
                ImageUrl = txtImageUrl.Text.Trim(),
                CategoryId = (int)cmbCategory.SelectedValue
            });

            MessageBox.Show("Product updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
