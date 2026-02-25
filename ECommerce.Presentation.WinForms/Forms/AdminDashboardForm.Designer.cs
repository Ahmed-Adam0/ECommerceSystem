namespace ECommerce.Presentation.WinForms
{
    partial class AdminDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Products = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            pnlCatToolbar = new Panel();
            button1 = new Button();
            button7 = new Button();
            button2 = new Button();
      
            button3 = new Button();
            textBox2 = new TextBox();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            pnlProdToolbar = new Panel();
            button6 = new Button();
            button8 = new Button();
            button5 = new Button();
            button4 = new Button();
            textBox4 = new TextBox();
            tabPage3 = new TabPage();
            panelOrdersContainer = new Panel();
            labelOrdersTitle = new Label();
            dataGridViewOrders = new DataGridView();
            pnlOrderToolbar = new Panel();
            buttonApproveOrder = new Button();
            buttonRejectOrder = new Button();
            comboBoxStatusFilter = new ComboBox();
            Products.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlCatToolbar.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            pnlProdToolbar.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            pnlOrderToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // Products
            // 
            Products.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // ترتيب التابات: Orders أول واحد، ثم Categories، ثم Products
            Products.Controls.Add(tabPage3);
            Products.Controls.Add(tabPage1);
            Products.Controls.Add(tabPage2);
            Products.Controls.Add(tabPage3);
            Products.Dock = DockStyle.Fill;
            Products.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Products.Location = new Point(0, 0);
            Products.Name = "Products";
            Products.SelectedIndex = 0;
            Products.Size = new Size(900, 580);
            Products.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(pnlCatToolbar);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(892, 544);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "📂  Categories";
            tabPage1.Click += tabPage1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.FromArgb(220, 220, 220);
            dataGridView1.Location = new Point(0, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(892, 489);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // pnlCatToolbar
            // 
            pnlCatToolbar.BackColor = Color.FromArgb(236, 240, 241);
            pnlCatToolbar.Controls.Add(button1);
            pnlCatToolbar.Controls.Add(button7);
            pnlCatToolbar.Controls.Add(button2);
           
            pnlCatToolbar.Controls.Add(button3);
            pnlCatToolbar.Controls.Add(textBox2);
            pnlCatToolbar.Dock = DockStyle.Top;
            pnlCatToolbar.Location = new Point(0, 0);
            pnlCatToolbar.Name = "pnlCatToolbar";
            pnlCatToolbar.Size = new Size(892, 55);
            pnlCatToolbar.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(39, 174, 96);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(10, 10);
            button1.Name = "button1";
            button1.Size = new Size(85, 34);
            button1.TabIndex = 0;
            button1.Text = "➕ Add";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(243, 156, 18);
            button7.Cursor = Cursors.Hand;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button7.ForeColor = Color.White;
            button7.Location = new Point(103, 10);
            button7.Name = "button7";
            button7.Size = new Size(85, 34);
            button7.TabIndex = 1;
            button7.Text = "✏️ Edit";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 57, 43);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(196, 10);
            button2.Name = "button2";
            button2.Size = new Size(95, 34);
            button2.TabIndex = 2;
            button2.Text = "🗑️ Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
           
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(41, 128, 185);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(718, 10);
            button3.Name = "button3";
            button3.Size = new Size(75, 34);
            button3.TabIndex = 4;
            button3.Text = "Search";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 10F);
            textBox2.Location = new Point(540, 12);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "🔍 Search...";
            textBox2.Size = new Size(170, 30);
            textBox2.TabIndex = 5;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Controls.Add(pnlProdToolbar);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(892, 544);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "📦  Products";
            tabPage2.Click += tabPage2_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(142, 68, 173);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.GridColor = Color.FromArgb(220, 220, 220);
            dataGridView2.Location = new Point(0, 55);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 35;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(892, 489);
            dataGridView2.TabIndex = 0;
            // 
            // pnlProdToolbar
            // 
            pnlProdToolbar.BackColor = Color.FromArgb(236, 240, 241);
            pnlProdToolbar.Controls.Add(button6);
            pnlProdToolbar.Controls.Add(button8);
            pnlProdToolbar.Controls.Add(button5);
            pnlProdToolbar.Controls.Add(button4);
            pnlProdToolbar.Controls.Add(textBox4);
            pnlProdToolbar.Dock = DockStyle.Top;
            pnlProdToolbar.Location = new Point(0, 0);
            pnlProdToolbar.Name = "pnlProdToolbar";
            pnlProdToolbar.Size = new Size(892, 55);
            pnlProdToolbar.TabIndex = 1;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(39, 174, 96);
            button6.Cursor = Cursors.Hand;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button6.ForeColor = Color.White;
            button6.Location = new Point(10, 10);
            button6.Name = "button6";
            button6.Size = new Size(85, 34);
            button6.TabIndex = 0;
            button6.Text = "➕ Add";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(243, 156, 18);
            button8.Cursor = Cursors.Hand;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button8.ForeColor = Color.White;
            button8.Location = new Point(103, 10);
            button8.Name = "button8";
            button8.Size = new Size(85, 34);
            button8.TabIndex = 1;
            button8.Text = "✏️ Edit";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(192, 57, 43);
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(196, 10);
            button5.Name = "button5";
            button5.Size = new Size(95, 34);
            button5.TabIndex = 2;
            button5.Text = "🗑️ Delete";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(142, 68, 173);
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10F);
            button4.ForeColor = Color.White;
            button4.Location = new Point(718, 10);
            button4.Name = "button4";
            button4.Size = new Size(75, 34);
            button4.TabIndex = 3;
            button4.Text = "Search";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Font = new Font("Segoe UI", 10F);
            textBox4.Location = new Point(490, 12);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "🔍 Search by name or category...";
            textBox4.Size = new Size(220, 30);
            textBox4.TabIndex = 4;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.White;
            tabPage3.Controls.Add(dataGridViewOrders);
            tabPage3.Controls.Add(pnlOrderToolbar);
            tabPage3.Location = new Point(4, 32);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Size = new Size(892, 544);
            tabPage3.Size = new Size(799, 416);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "\U0001f6d2  Orders";
            //=========================================================
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
            dataGridViewOrders.BackgroundColor = Color.White;
            dataGridViewOrders.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridViewOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridViewOrders.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.GridColor = Color.FromArgb(220, 220, 220);
            dataGridViewOrders.Location = new Point(0, 55);
            dataGridViewOrders.Location = new Point(57, 74);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.RowHeadersVisible = false;
            dataGridViewOrders.RowHeadersWidth = 51;
            dataGridViewOrders.RowTemplate.Height = 35;
            dataGridViewOrders.Size = new Size(892, 489);
            dataGridViewOrders.TabIndex = 0;
            dataGridViewOrders.TabIndex = 14;
            dataGridViewOrders.CellDoubleClick += dataGridViewOrders_CellDoubleClick;
            // 
            // pnlOrderToolbar
            pnlOrderToolbar.BackColor = Color.FromArgb(236, 240, 241);
            pnlOrderToolbar.Controls.Add(buttonApproveOrder);
            pnlOrderToolbar.Controls.Add(buttonRejectOrder);
            pnlOrderToolbar.Controls.Add(comboBoxStatusFilter);
            pnlOrderToolbar.Dock = DockStyle.Top;
            pnlOrderToolbar.Location = new Point(0, 0);
            pnlOrderToolbar.Name = "pnlOrderToolbar";
            pnlOrderToolbar.Size = new Size(892, 55);
            pnlOrderToolbar.TabIndex = 1;

            // 
            // buttonApproveOrder
            buttonApproveOrder.BackColor = Color.FromArgb(39, 174, 96);
            buttonApproveOrder.Cursor = Cursors.Hand;
            buttonApproveOrder.FlatAppearance.BorderSize = 0;
            buttonApproveOrder.FlatStyle = FlatStyle.Flat;
            buttonApproveOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonApproveOrder.ForeColor = Color.White;
            buttonApproveOrder.Location = new Point(10, 10);
            buttonApproveOrder.Location = new Point(57, 20);
            buttonApproveOrder.Size = new Size(110, 34);
            buttonApproveOrder.TabIndex = 0;
            buttonApproveOrder.Text = "✅ Approve";
            buttonApproveOrder.Text = "Approve";
            buttonApproveOrder.UseVisualStyleBackColor = false;
            buttonApproveOrder.Click += buttonApproveOrder_Click;
            // 
            // buttonRejectOrder
            buttonRejectOrder.BackColor = Color.FromArgb(192, 57, 43);
            buttonRejectOrder.Cursor = Cursors.Hand;
            buttonRejectOrder.FlatAppearance.BorderSize = 0;
            buttonRejectOrder.FlatStyle = FlatStyle.Flat;
            buttonRejectOrder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonRejectOrder.ForeColor = Color.White;
            buttonRejectOrder.Location = new Point(128, 10);
            buttonRejectOrder.Location = new Point(157, 20);
            buttonRejectOrder.Size = new Size(100, 34);
            buttonRejectOrder.TabIndex = 1;
            buttonRejectOrder.Text = "❌ Reject";
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
            // comboBoxStatusFilter
            // 
            comboBoxStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusFilter.Font = new Font("Segoe UI", 10F);
            comboBoxStatusFilter.Items.AddRange(new object[] { "All", "Pending", "Processing", "Delivered" });
            comboBoxStatusFilter.Location = new Point(530, 13);
            comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            comboBoxStatusFilter.Size = new Size(200, 31);
            comboBoxStatusFilter.TabIndex = 2;
            comboBoxStatusFilter.SelectedIndexChanged += comboBoxStatusFilter_SelectedIndexChanged;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            BackColor = Color.White;
            ClientSize = new Size(900, 580);
            ClientSize = new Size(800, 450);
            Controls.Add(Products);
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += AdminDashboardForm_Load;
            Products.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlCatToolbar.ResumeLayout(false);
            pnlCatToolbar.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            pnlProdToolbar.ResumeLayout(false);
            pnlProdToolbar.PerformLayout();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            pnlOrderToolbar.ResumeLayout(false);
            ResumeLayout(false);
        }


        private System.Windows.Forms.TabControl Products;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel pnlCatToolbar;
        private System.Windows.Forms.Panel pnlProdToolbar;
        private System.Windows.Forms.Panel pnlOrderToolbar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button2;
    
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button buttonApproveOrder;
        private System.Windows.Forms.Button buttonRejectOrder;
        private System.Windows.Forms.ComboBox comboBoxStatusFilter;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private Button buttonRejectOrder;
    }
}