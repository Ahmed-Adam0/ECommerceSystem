namespace ECommerce.Presentation.WinForms.Forms
{
    partial class AddProductForm
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
            // Left column
            label6 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            // Right column
            label3 = new System.Windows.Forms.Label();
            textBox4 = new System.Windows.Forms.TextBox();
            lblImageUrl = new System.Windows.Forms.Label();
            textBox5 = new System.Windows.Forms.TextBox();
            lblNote = new System.Windows.Forms.Label();
            // Buttons
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
            lblTitle.Text = "➕  Add New Product";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(20, 13);

            // pnlBody
            pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBody.Padding = new System.Windows.Forms.Padding(20);
            pnlBody.Controls.Add(lblNote);
            pnlBody.Controls.Add(textBox5);
            pnlBody.Controls.Add(lblImageUrl);
            pnlBody.Controls.Add(textBox4);
            pnlBody.Controls.Add(label3);
            pnlBody.Controls.Add(comboBox1);
            pnlBody.Controls.Add(label5);
            pnlBody.Controls.Add(textBox3);
            pnlBody.Controls.Add(label4);
            pnlBody.Controls.Add(textBox2);
            pnlBody.Controls.Add(label1);
            pnlBody.Controls.Add(textBox1);
            pnlBody.Controls.Add(label6);

            // ── LEFT COLUMN ──

            // label6 — Name
            label6.Text = "Product Name *";
            label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label6.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(20, 25);

            // textBox1 — Name
            textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBox1.Size = new System.Drawing.Size(270, 32);
            textBox1.Location = new System.Drawing.Point(20, 48);
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox1.PlaceholderText = "e.g. Laptop Pro";
            textBox1.Name = "textBox1";

            // label1 — Price
            label1.Text = "Price ($) *";
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 100);

            // textBox2 — Price
            textBox2.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBox2.Size = new System.Drawing.Size(270, 32);
            textBox2.Location = new System.Drawing.Point(20, 123);
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox2.PlaceholderText = "e.g. 999.99";
            textBox2.Name = "textBox2";

            // label4 — Stock
            label4.Text = "Stock *";
            label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label4.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(20, 175);

            // textBox3 — Stock
            textBox3.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBox3.Size = new System.Drawing.Size(270, 32);
            textBox3.Location = new System.Drawing.Point(20, 198);
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox3.PlaceholderText = "e.g. 50";
            textBox3.Name = "textBox3";

            // label5 — Category
            label5.Text = "Category *";
            label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label5.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(20, 250);

            // comboBox1 — Category
            comboBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            comboBox1.Size = new System.Drawing.Size(270, 32);
            comboBox1.Location = new System.Drawing.Point(20, 273);
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            comboBox1.Name = "comboBox1";

            // ── RIGHT COLUMN ──

            // label3 — Description
            label3.Text = "Description";
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(320, 25);

            // textBox4 — Description
            textBox4.Font = new System.Drawing.Font("Segoe UI", 10F);
            textBox4.Size = new System.Drawing.Size(310, 120);
            textBox4.Location = new System.Drawing.Point(320, 48);
            textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox4.Multiline = true;
            textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox4.PlaceholderText = "Product description...";
            textBox4.Name = "textBox4";

            // lblImageUrl
            lblImageUrl.Text = "Main Image URL";
            lblImageUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblImageUrl.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblImageUrl.AutoSize = true;
            lblImageUrl.Location = new System.Drawing.Point(320, 190);

            // textBox5 — ImageUrl
            textBox5.Font = new System.Drawing.Font("Segoe UI", 10F);
            textBox5.Size = new System.Drawing.Size(310, 32);
            textBox5.Location = new System.Drawing.Point(320, 213);
            textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox5.PlaceholderText = "https://example.com/product.jpg";
            textBox5.Name = "textBox5";

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
            button1.Location = new System.Drawing.Point(420, 10);
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
            btnCancel.Location = new System.Drawing.Point(310, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            // AddProductForm
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(680, 430);
            BackColor = System.Drawing.Color.White;
            Controls.Add(pnlBody);
            Controls.Add(pnlButtons);
            Controls.Add(pnlTop);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProductForm";
            Text = "Add Product";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Load += AddProductForm_Load;

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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblImageUrl;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
    }
}