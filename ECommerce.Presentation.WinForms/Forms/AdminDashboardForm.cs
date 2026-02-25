using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.DTOs.OrderDtos;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Domain.Enums;
using ECommerce.Presentation.WinForms.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ECommerce.Presentation.WinForms
{
    public partial class AdminDashboardForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private List<CategoryDto> _allCategories = new();
        private List<ProductDto> _allProducts = new();
        private List<OrderDto> _allOrders = new();

        public AdminDashboardForm(ICategoryService categoryService, IProductService productService, IOrderService orderService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
        }

        // ══════════════════════════════
        //  LOAD
        // ══════════════════════════════
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
            LoadOrders();
        }

        // ══════════════════════════════
        //  CATEGORIES
        // ══════════════════════════════
        private void LoadCategories()
        {
            _allCategories = _categoryService.GetAllCategories();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _allCategories;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addForm = new AddCategoryForm(_categoryService);
            addForm.ShowDialog();
            LoadCategories();
        }

        private void button7_Click(object sender, EventArgs e) // ✏️ Edit Category
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not CategoryDto selected)
            {
                MessageBox.Show("Please select a category to edit.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var editForm = new EditCategoryForm(_categoryService, selected.Id, selected.Name, selected.ImageUrl);
            editForm.ShowDialog();
            LoadCategories();
        }

        private void button2_Click(object sender, EventArgs e) // 🗑️ Delete Category
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not CategoryDto selected)
            {
                MessageBox.Show("Please select a category to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete \"{selected.Name}\"?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                _categoryService.DeleteCategory(selected.Id);
                LoadCategories();
            }
        }

        private void button3_Click(object sender, EventArgs e) // 🔍 Search Category
        {
            string keyword = textBox2.Text.Trim().ToLower();
            dataGridView1.DataSource = string.IsNullOrEmpty(keyword)
                ? _allCategories
                : _allCategories.Where(c => c.Name.ToLower().Contains(keyword)).ToList();
        }

        // ══════════════════════════════
        //  PRODUCTS
        // ══════════════════════════════
        private void LoadProducts()
        {
            _allProducts = _productService.GetAllProducts();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = _allProducts;
        }
        private void button6_Click(object sender, EventArgs e) // ➕ Add Product
        {
            var addForm = new AddProductForm(_productService, _categoryService);
            addForm.ShowDialog();
            LoadProducts();
        }

        private void button8_Click(object sender, EventArgs e) // ✏️ Edit Product
        {
            if (dataGridView2.CurrentRow?.DataBoundItem is not ProductDto selected)
            {
                MessageBox.Show("Please select a product to edit.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var editForm = new EditProductForm(_productService, _categoryService, selected);
            editForm.ShowDialog();
            LoadProducts();
        }

        private void button5_Click(object sender, EventArgs e) // 🗑️ Delete Product
        {
            if (dataGridView2.CurrentRow?.DataBoundItem is not ProductDto selected)
            {
                MessageBox.Show("Please select a product to delete.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete \"{selected.Name}\"?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                _productService.DeleteProduct(selected.Id);
                LoadProducts();
            }
        }

        private void button4_Click(object sender, EventArgs e) // 🔍 Search Product
        {
            string keyword = textBox4.Text.Trim().ToLower();
            dataGridView2.DataSource = string.IsNullOrEmpty(keyword)
                ? _allProducts
                : _allProducts.Where(p => p.Name.ToLower().Contains(keyword) ||
                                          (p.CategoryName?.ToLower().Contains(keyword) ?? false)).ToList();
        }

        // ══════════════════════════════
        //  ORDERS
        // ══════════════════════════════
        private void LoadOrders()
        {
            _allOrders = _orderService.GetAllOrders();
            dataGridViewOrders.DataSource = null;
            dataGridViewOrders.DataSource = _allOrders;
        }

        private void FilterOrdersByStatus()
        {
            if (comboBoxStatusFilter.SelectedItem == null ||
                comboBoxStatusFilter.SelectedItem.ToString() == "All")
            {
                dataGridViewOrders.DataSource = _allOrders;
                return;
            }

            string selectedStatus = comboBoxStatusFilter.SelectedItem.ToString();
            dataGridViewOrders.DataSource = _allOrders
                .Where(o => o.Status.Equals(selectedStatus, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private void comboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterOrdersByStatus();
        }

        private void buttonApproveOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow?.DataBoundItem is not OrderDto selectedOrder)
            {
                MessageBox.Show("Please select an order to approve.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Admin approval => move order to Shipping
            _orderService.UpdateOrder(new UpdateOrderDto
            {
                Id = selectedOrder.Id,
                Status = OrderStatus.Shipping
            });

            LoadOrders();
            FilterOrdersByStatus();
        }

        private void buttonRejectOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow?.DataBoundItem is not OrderDto selectedOrder)
            {
                MessageBox.Show("Please select an order to reject.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to reject this order?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // ❌ فقط نغيّر الحالة حتى يراها العميل لاحقًا
                _orderService.UpdateOrder(new UpdateOrderDto
                {
                    Id = selectedOrder.Id,
                    Status = OrderStatus.Canceled
                });

                LoadOrders();
                FilterOrdersByStatus();
            }
        }

        private void dataGridViewOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridViewOrders.Rows[e.RowIndex].DataBoundItem is not OrderDto selectedOrder) return;

            var detailsForm = new OrderDetailsForm(selectedOrder);
            detailsForm.ShowDialog();
        }

        private void buttonViewOrderDetails_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow?.DataBoundItem is not OrderDto selectedOrder)
            {
                MessageBox.Show("Please select an order to view details.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detailsForm = new OrderDetailsForm(selectedOrder);
            detailsForm.ShowDialog();
        }

        private void buttonViewOrderDetails_MouseEnter(object sender, EventArgs e)
        {
            // لون أغمق بسيط عند الـ hover
            buttonViewOrderDetails.BackColor = Color.FromArgb(31, 97, 141);
        }

        private void buttonViewOrderDetails_MouseLeave(object sender, EventArgs e)
        {
            // نرجّع اللون الأساسي للزر
            buttonViewOrderDetails.BackColor = Color.FromArgb(41, 128, 185);
        }

        // ── Empty handlers ──
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void tabPage3_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}