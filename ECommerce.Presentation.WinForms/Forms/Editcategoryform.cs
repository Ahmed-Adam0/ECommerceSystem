using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.Services;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ECommerce.Presentation.WinForms.Forms
{
    public partial class EditCategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly int _id;

        public EditCategoryForm(ICategoryService categoryService, int id, string currentName, string currentImageUrl)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _id = id;
            txtName.Text = currentName;
            txtImageUrl.Text = currentImageUrl;
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

            _categoryService.UpdateCategory(new UpdateCategoryDto
            {
                Id = _id,
                Name = txtName.Text.Trim(),
                ImageUrl = txtImageUrl.Text.Trim()
            });

            MessageBox.Show("Category updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
