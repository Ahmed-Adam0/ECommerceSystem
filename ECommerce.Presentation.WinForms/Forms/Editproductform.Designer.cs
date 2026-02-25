namespace ECommerce.Presentation.WinForms.Forms
{
    partial class EditProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            pnlBody = new System.Windows.Forms.Panel();
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblPrice = new System.Windows.Forms.Label();
            txtPrice = new System.Windows.Forms.TextBox();
            lblStock = new System.Windows.Forms.Label();
            txtStock = new System.Windows.Forms.TextBox();
            lblCategory = new System.Windows.Forms.Label();
            cmbCategory = new System.Windows.Forms.ComboBox();
            lblDescription = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            lblImageUrl = new System.Windows.Forms.Label();
            txtImageUrl = new System.Windows.Forms.TextBox();
            lblNote = new System.Windows.Forms.Label();
            pnlButtons = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            pnlTop.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // pnlTop
            pnlTop.BackColor = System.Drawing.Color.FromArgb(142, 68, 173);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Height = 55;

            // lblTitle
            lblTitle.Text = "✏️  Edit Product";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(20, 13);

            // pnlBody
            pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBody.Padding = new System.Windows.Forms.Padding(20);
            pnlBody.Controls.Add(lblNote);
            pnlBody.Controls.Add(txtImageUrl);
            pnlBody.Controls.Add(lblImageUrl);
            pnlBody.Controls.Add(txtDescription);
            pnlBody.Controls.Add(lblDescription);
            pnlBody.Controls.Add(cmbCategory);
            pnlBody.Controls.Add(lblCategory);
            pnlBody.Controls.Add(txtStock);
            pnlBody.Controls.Add(lblStock);
            pnlBody.Controls.Add(txtPrice);
            pnlBody.Controls.Add(lblPrice);
            pnlBody.Controls.Add(txtName);
            pnlBody.Controls.Add(lblName);

            // ── LEFT COLUMN ──

            // lblName
            lblName.Text = "Product Name *";
            lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblName.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(20, 25);

            // txtName
            txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtName.Size = new System.Drawing.Size(270, 32);
            txtName.Location = new System.Drawing.Point(20, 48);
            txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtName.Name = "txtName";

            // lblPrice
            lblPrice.Text = "Price ($) *";
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblPrice.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblPrice.AutoSize = true;
            lblPrice.Location = new System.Drawing.Point(20, 100);

            // txtPrice
            txtPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtPrice.Size = new System.Drawing.Size(270, 32);
            txtPrice.Location = new System.Drawing.Point(20, 123);
            txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPrice.Name = "txtPrice";

            // lblStock
            lblStock.Text = "Stock *";
            lblStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblStock.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblStock.AutoSize = true;
            lblStock.Location = new System.Drawing.Point(20, 175);

            // txtStock
            txtStock.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtStock.Size = new System.Drawing.Size(270, 32);
            txtStock.Location = new System.Drawing.Point(20, 198);
            txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtStock.Name = "txtStock";

            // lblCategory
            lblCategory.Text = "Category *";
            lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblCategory.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblCategory.AutoSize = true;
            lblCategory.Location = new System.Drawing.Point(20, 250);

            // cmbCategory
            cmbCategory.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbCategory.Size = new System.Drawing.Size(270, 32);
            cmbCategory.Location = new System.Drawing.Point(20, 273);
            cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbCategory.Name = "cmbCategory";

            // ── RIGHT COLUMN ──

            // lblDescription
            lblDescription.Text = "Description";
            lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblDescription.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblDescription.AutoSize = true;
            lblDescription.Location = new System.Drawing.Point(320, 25);

            // txtDescription
            txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtDescription.Size = new System.Drawing.Size(310, 120);
            txtDescription.Location = new System.Drawing.Point(320, 48);
            txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtDescription.Name = "txtDescription";

            // lblImageUrl
            lblImageUrl.Text = "Main Image URL";
            lblImageUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblImageUrl.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblImageUrl.AutoSize = true;
            lblImageUrl.Location = new System.Drawing.Point(320, 190);

            // txtImageUrl
            txtImageUrl.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtImageUrl.Size = new System.Drawing.Size(310, 32);
            txtImageUrl.Location = new System.Drawing.Point(320, 213);
            txtImageUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtImageUrl.PlaceholderText = "https://example.com/product.jpg";
            txtImageUrl.Name = "txtImageUrl";

            // lblNote
            lblNote.Text = "ℹ️  Paste a direct image URL link";
            lblNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblNote.ForeColor = System.Drawing.Color.Gray;
            lblNote.AutoSize = true;
            lblNote.Location = new System.Drawing.Point(320, 250);

            // pnlButtons
            pnlButtons.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlButtons.Height = 60;
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(button1);

            // button1 — Save
            button1.Text = "💾  Save";
            button1.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            button1.ForeColor = System.Drawing.Color.White;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            button1.Size = new System.Drawing.Size(120, 38);
            button1.Location = new System.Drawing.Point(390, 10);
            button1.Name = "button1";
            button1.Cursor = System.Windows.Forms.Cursors.Hand;
            button1.Click += button1_Click;

            // btnCancel
            btnCancel.Text = "Cancel";
            btnCancel.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnCancel.Size = new System.Drawing.Size(100, 38);
            btnCancel.Location = new System.Drawing.Point(280, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            // EditProductForm
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(670, 430);
            BackColor = System.Drawing.Color.White;
            Controls.Add(pnlBody);
            Controls.Add(pnlButtons);
            Controls.Add(pnlTop);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditProductForm";
            Text = "Edit Product";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Load += EditProductForm_Load;

            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblImageUrl;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
    }
}