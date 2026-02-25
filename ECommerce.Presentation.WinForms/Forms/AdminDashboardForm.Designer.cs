namespace ECommerce.Presentation.WinForms
{
    partial class AdminDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Products = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            textBox2 = new TextBox();
            button1 = new Button();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            button4 = new Button();
            button5 = new Button();
            textBox4 = new TextBox();
            button6 = new Button();
            tabPage3 = new TabPage();
            panelOrdersContainer = new Panel();
            labelOrdersTitle = new Label();
            dataGridViewOrders = new DataGridView();
            comboBoxStatusFilter = new ComboBox();
            buttonApproveOrder = new Button();
            buttonRejectOrder = new Button();
            buttonViewOrderDetails = new Button();
            Products.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            SuspendLayout();
            // 
            // Products
            // 
            Products.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // ترتيب التابات: Orders أول واحد، ثم Categories، ثم Products
            Products.Controls.Add(tabPage3);
            Products.Controls.Add(tabPage1);
            Products.Controls.Add(tabPage2);
            Products.Location = new Point(8, 8);
            Products.Name = "Products";
            Products.SelectedIndex = 0;
            Products.Size = new Size(1180, 680);
            Products.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.WhiteSmoke;
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1172, 647);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Categories";
            tabPage1.Click += tabPage1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 85);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1080, 520);
            dataGridView1.TabIndex = 7;
            // 
            // button3
            // 
            button3.Location = new Point(403, 23);
            button3.Name = "button3";
            button3.Size = new Size(37, 29);
            button3.TabIndex = 12;
            button3.Text = "🔍";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.DimGray;
            textBox1.Location = new Point(106, 25);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "add Category...";
            textBox1.Size = new Size(291, 27);
            textBox1.TabIndex = 10;
            // 
            // button2
            // 
            button2.BackColor = Color.Firebrick;
            button2.ForeColor = SystemColors.ControlLight;
            button2.Location = new Point(23, 25);
            button2.Name = "button2";
            button2.Size = new Size(34, 36);
            button2.TabIndex = 11;
            button2.Text = "🗑️";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.ForeColor = Color.DimGray;
            textBox2.Location = new Point(446, 23);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Search...";
            textBox2.Size = new Size(291, 27);
            textBox2.TabIndex = 8;
            // 
            // button1
            // 
            button1.BackColor = Color.SteelBlue;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(63, 25);
            button1.Name = "button1";
            button1.Size = new Size(37, 36);
            button1.TabIndex = 9;
            button1.Text = "➕";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(button6);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1172, 647);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Products";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(40, 74);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(1080, 520);
            dataGridView2.TabIndex = 13;
            // 
            // button4
            // 
            button4.Location = new Point(402, 20);
            button4.Name = "button4";
            button4.Size = new Size(37, 29);
            button4.TabIndex = 18;
            button4.Text = "🔍";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Firebrick;
            button5.FlatAppearance.BorderSize = 0;
            button5.ForeColor = SystemColors.ControlLight;
            button5.Location = new Point(57, 20);
            button5.Name = "button5";
            button5.Size = new Size(40, 36);
            button5.TabIndex = 17;
            button5.Text = "🗑️";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(445, 20);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(285, 27);
            textBox4.TabIndex = 14;
            // 
            // button6
            // 
            button6.BackColor = Color.SteelBlue;
            button6.FlatAppearance.BorderSize = 0;
            button6.ForeColor = SystemColors.ButtonHighlight;
            button6.Location = new Point(103, 20);
            button6.Name = "button6";
            button6.Size = new Size(39, 36);
            button6.TabIndex = 15;
            button6.Text = "➕";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(24, 30, 54);
            tabPage3.Controls.Add(panelOrdersContainer);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1172, 647);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Orders";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;


            // panelOrdersContainer
            // 
            panelOrdersContainer.BackColor = Color.FromArgb(37, 42, 64);
            panelOrdersContainer.BorderStyle = BorderStyle.None;
            panelOrdersContainer.Location = new Point(24, 20);
            panelOrdersContainer.Name = "panelOrdersContainer";
            panelOrdersContainer.Size = new Size(1120, 600);
            panelOrdersContainer.TabIndex = 0;
            panelOrdersContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelOrdersContainer.Controls.Add(buttonViewOrderDetails);
            panelOrdersContainer.Controls.Add(buttonRejectOrder);
            panelOrdersContainer.Controls.Add(buttonApproveOrder);
            panelOrdersContainer.Controls.Add(comboBoxStatusFilter);
            panelOrdersContainer.Controls.Add(dataGridViewOrders);
            panelOrdersContainer.Controls.Add(labelOrdersTitle);

            // 
            // labelOrdersTitle
            // 
            labelOrdersTitle.AutoSize = true;
            labelOrdersTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelOrdersTitle.ForeColor = Color.WhiteSmoke;
            labelOrdersTitle.Location = new Point(20, 15);
            labelOrdersTitle.Name = "labelOrdersTitle";
            labelOrdersTitle.Size = new Size(162, 32);
            labelOrdersTitle.TabIndex = 0;
            labelOrdersTitle.Text = "Manage Orders";

            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrders.BackgroundColor = Color.FromArgb(46, 51, 73);
            dataGridViewOrders.EnableHeadersVisualStyles = false;
            dataGridViewOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 76, 129);
            dataGridViewOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewOrders.DefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewOrders.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dataGridViewOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(37, 42, 64);
            dataGridViewOrders.GridColor = Color.FromArgb(67, 76, 94);
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Location = new Point(20, 120);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.RowHeadersWidth = 51;
            dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrders.Size = new Size(1080, 450);
            dataGridViewOrders.TabIndex = 14;
            dataGridViewOrders.CellDoubleClick += dataGridViewOrders_CellDoubleClick;

            // 
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusFilter.FormattingEnabled = true;
            comboBoxStatusFilter.Items.AddRange(new object[] { "All", "Pending", "Shipping", "Delivered", "Canceled" });
            comboBoxStatusFilter.Location = new Point(780, 25);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(320, 28);
            comboBoxStatusFilter.TabIndex = 15;
            comboBoxStatusFilter.SelectedIndexChanged += comboBoxStatusFilter_SelectedIndexChanged;

            // 
            // buttonApproveOrder
            // 
            buttonApproveOrder.BackColor = Color.FromArgb(39, 174, 96);
            buttonApproveOrder.FlatStyle = FlatStyle.Flat;
            buttonApproveOrder.FlatAppearance.BorderSize = 0;
            buttonApproveOrder.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 132, 73);
            buttonApproveOrder.ForeColor = Color.White;
            buttonApproveOrder.Location = new Point(20, 60);
            buttonApproveOrder.Name = "buttonApproveOrder";
            buttonApproveOrder.Size = new Size(170, 50);
            buttonApproveOrder.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonApproveOrder.TabIndex = 16;
            buttonApproveOrder.Text = "Approve";
            buttonApproveOrder.UseVisualStyleBackColor = false;
            buttonApproveOrder.Click += buttonApproveOrder_Click;

            // 
            // buttonRejectOrder
            // 
            buttonRejectOrder.BackColor = Color.FromArgb(192, 57, 43);
            buttonRejectOrder.FlatStyle = FlatStyle.Flat;
            buttonRejectOrder.FlatAppearance.BorderSize = 0;
            buttonRejectOrder.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 50, 38);
            buttonRejectOrder.ForeColor = Color.White;
            buttonRejectOrder.Location = new Point(170, 60);
            buttonRejectOrder.Name = "buttonRejectOrder";
            buttonRejectOrder.Size = new Size(170, 50);
            buttonRejectOrder.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRejectOrder.TabIndex = 17;
            buttonRejectOrder.Text = "Reject";
            buttonRejectOrder.UseVisualStyleBackColor = false;
            buttonRejectOrder.Click += buttonRejectOrder_Click;

            // 
            // buttonViewOrderDetails
            // 
            buttonViewOrderDetails.BackColor = Color.FromArgb(41, 128, 185);
            buttonViewOrderDetails.FlatStyle = FlatStyle.Flat;
            buttonViewOrderDetails.FlatAppearance.BorderSize = 0;
            buttonViewOrderDetails.FlatAppearance.MouseOverBackColor = Color.FromArgb(31, 97, 141);
            buttonViewOrderDetails.ForeColor = Color.White;
            buttonViewOrderDetails.Location = new Point(320, 60);
            buttonViewOrderDetails.Name = "buttonViewOrderDetails";
            buttonViewOrderDetails.Size = new Size(190, 50);
            buttonViewOrderDetails.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonViewOrderDetails.TabIndex = 18;
            buttonViewOrderDetails.Text = "View Details";
            buttonViewOrderDetails.UseVisualStyleBackColor = false;
            buttonViewOrderDetails.Click += buttonViewOrderDetails_Click;
            buttonViewOrderDetails.MouseEnter += buttonViewOrderDetails_MouseEnter;
            buttonViewOrderDetails.MouseLeave += buttonViewOrderDetails_MouseLeave;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(1200, 700);
            Controls.Add(Products);
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += AdminDashboardForm_Load;
            Products.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabControl Products;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private Button button3;
        private TextBox textBox1;
        private Button button2;
        private TextBox textBox2;
        private Button button1;
        private DataGridView dataGridView2;
        private Button button4;
        private Button button5;
        private TextBox textBox4;
        private Button button6;
        private TabPage tabPage3;
        private Panel panelOrdersContainer;
        private Label labelOrdersTitle;
        private DataGridView dataGridViewOrders;
        private ComboBox comboBoxStatusFilter;
        private Button buttonApproveOrder;
        private Button buttonRejectOrder;
        private Button buttonViewOrderDetails;
    }
}