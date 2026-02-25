using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.Services;

namespace ECommerce.Presentation.WinForms.Forms
{
    public partial class EditCategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly int _id;
        public EditCategoryForm(ICategoryService categoryService, int id, string currentName)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _id = id;
            textBox1.Text = currentName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Name is required.");
                return;
            }

            _categoryService.UpdateCategory(new UpdateCategoryDto
            {
                Id = _id,
                Name = textBox1.Text.Trim()
            });

            MessageBox.Show("Category updated!");
            this.Close();
        }
    }
    }
}
