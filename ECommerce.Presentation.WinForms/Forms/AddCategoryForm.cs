using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.Services;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ECommerce.Presentation.WinForms.Forms
{
    public partial class AddCategoryForm : Form
    {
        private readonly ICategoryService _categoryService;

        public AddCategoryForm(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Category name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            _categoryService.CreateCategory(new CreateCategoryDto
            {
                Name = txtName.Text.Trim(),
                ImageUrl = txtImageUrl.Text.Trim()
            });

            MessageBox.Show("Category added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}