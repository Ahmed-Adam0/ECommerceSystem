using ECommerce.ApplicationLayer.DTOs.CategoryDTos;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.DTOs.OrderDtos;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Domain.Enums;
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
        private readonly IOrderService _orderService;
        private List<OrderDto> _allOrders = new();


        public AdminDashboardForm(ICategoryService categoryService, IProductService productService, IOrderService orderService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
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

        private void LoadOrders()
        {
            _allOrders = _orderService.GetAllOrders();
            dataGridViewOrders.DataSource = _allOrders;
        }

        private void FilterOrdersByStatus()
        {
            if (comboBoxStatusFilter.SelectedItem == null || comboBoxStatusFilter.SelectedItem.ToString() == "All")
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
            if (dataGridViewOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select an order to approve.");
                return;
            }

            if (dataGridViewOrders.CurrentRow.DataBoundItem is not OrderDto selectedOrder)
                return;

            _orderService.UpdateOrder(new UpdateOrderDto
            {
                Id = selectedOrder.Id,
                Status = OrderStatus.Shipping
            });

            MessageBox.Show("Order has been approved and moved to Shipping status.", "Order Approved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadOrders();
            FilterOrdersByStatus();
        }

        private void buttonRejectOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select an order to reject.");
                return;
            }

            if (dataGridViewOrders.CurrentRow.DataBoundItem is not OrderDto selectedOrder)
                return;

            var confirm = MessageBox.Show("Are you sure you want to reject this order?",
                "Confirm", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                // Change status to Canceled so customer can see it later
                _orderService.UpdateOrder(new UpdateOrderDto
                {
                    Id = selectedOrder.Id,
                    Status = OrderStatus.Canceled
                });

                MessageBox.Show("Order has been rejected and marked as Canceled.", "Order Rejected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrders();
                FilterOrdersByStatus();
            }
        }
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
            LoadOrders();
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

        private void dataGridViewOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridViewOrders.Rows[e.RowIndex].DataBoundItem is not OrderDto selectedOrder)
                return;

            var detailsForm = new OrderDetailsForm(selectedOrder);
            detailsForm.ShowDialog();
        }

        private void buttonViewOrderDetails_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select an order to view details.");
                return;
            }

            if (dataGridViewOrders.CurrentRow.DataBoundItem is not OrderDto selectedOrder)
                return;

            var detailsForm = new OrderDetailsForm(selectedOrder);
            detailsForm.ShowDialog();
        }

        private void buttonViewOrderDetails_MouseEnter(object sender, EventArgs e)
        {
            buttonViewOrderDetails.BackColor = Color.FromArgb(41, 128, 185);
        }

        private void buttonViewOrderDetails_MouseLeave(object sender, EventArgs e)
        {
            buttonViewOrderDetails.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

    }
}
