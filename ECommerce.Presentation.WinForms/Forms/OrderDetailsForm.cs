using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ECommerce.ApplicationLayer.DTOs.OrderDtos;

namespace ECommerce.Presentation.WinForms.Forms
{
    public class OrderDetailsForm : Form
    {
        private readonly OrderDto _order;

        private Label lblHeader;
        private Label lblCustomer;
        private Label lblDate;
        private Label lblTotal;
        private DataGridView dataGridViewItems;

        public OrderDetailsForm(OrderDto order)
        {
            _order = order;
            InitializeComponent();
            LoadOrderDetails();
        }

        private void InitializeComponent()
        {
            Text = $"Order Details - #{_order.Id}";
            Size = new Size(700, 500);
            StartPosition = FormStartPosition.CenterParent;

            lblHeader = new Label
            {
                Text = $"Order #{_order.Id}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            lblCustomer = new Label
            {
                AutoSize = true,
                Location = new Point(20, 60)
            };

            lblDate = new Label
            {
                AutoSize = true,
                Location = new Point(20, 90)
            };

            lblTotal = new Label
            {
                AutoSize = true,
                Location = new Point(20, 120)
            };

            dataGridViewItems = new DataGridView
            {
                Location = new Point(20, 160),
                Size = new Size(640, 260),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            Controls.Add(lblHeader);
            Controls.Add(lblCustomer);
            Controls.Add(lblDate);
            Controls.Add(lblTotal);
            Controls.Add(dataGridViewItems);
        }

        private void LoadOrderDetails()
        {
            lblCustomer.Text = $"Customer: {_order.CustomerName}";
            lblDate.Text = $"Date: {_order.OrderDate}";
            lblTotal.Text = $"Total: {_order.TotalPrice:C}";

            // Items might be null if not filled in service
            if (_order.Items != null && _order.Items.Any())
            {
                dataGridViewItems.DataSource = _order.Items
                    .Select(i => new
                    {
                        i.ProductName,
                        i.UnitPrice,
                        i.Quantity,
                        LineTotal = i.UnitPrice * i.Quantity
                    })
                    .ToList();
            }
        }
    }
}

