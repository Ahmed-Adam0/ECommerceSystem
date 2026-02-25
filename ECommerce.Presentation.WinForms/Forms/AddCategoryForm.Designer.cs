namespace ECommerce.Presentation.WinForms.Forms
{
    partial class AddCategoryForm
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
            pnlTop.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Height = 55;

            // lblTitle
            lblTitle.Text = "➕  Add New Category";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(20, 13);

            // pnlBody
            pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBody.Padding = new System.Windows.Forms.Padding(30, 20, 30, 10);
            pnlBody.Controls.Add(lblNote);
            pnlBody.Controls.Add(txtImageUrl);
            pnlBody.Controls.Add(lblImageUrl);
            pnlBody.Controls.Add(txtName);
            pnlBody.Controls.Add(lblName);

            // lblName
            lblName.Text = "Category Name *";
            lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblName.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(30, 30);

            // txtName
            txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtName.Size = new System.Drawing.Size(360, 32);
            txtName.Location = new System.Drawing.Point(30, 55);
            txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtName.PlaceholderText = "e.g. Electronics";
            txtName.Name = "txtName";

            // lblImageUrl
            lblImageUrl.Text = "Image URL (optional)";
            lblImageUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblImageUrl.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            lblImageUrl.AutoSize = true;
            lblImageUrl.Location = new System.Drawing.Point(30, 110);

            // txtImageUrl
            txtImageUrl.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtImageUrl.Size = new System.Drawing.Size(360, 32);
            txtImageUrl.Location = new System.Drawing.Point(30, 135);
            txtImageUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtImageUrl.PlaceholderText = "https://example.com/image.jpg";
            txtImageUrl.Name = "txtImageUrl";

            // lblNote
            lblNote.Text = "ℹ️  Paste a direct image URL link";
            lblNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblNote.ForeColor = System.Drawing.Color.Gray;
            lblNote.AutoSize = true;
            lblNote.Location = new System.Drawing.Point(30, 172);

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
            button1.Location = new System.Drawing.Point(220, 10);
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
            btnCancel.Location = new System.Drawing.Point(110, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            // AddCategoryForm
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(440, 320);
            BackColor = System.Drawing.Color.White;
            Controls.Add(pnlBody);
            Controls.Add(pnlButtons);
            Controls.Add(pnlTop);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddCategoryForm";
            Text = "Add Category";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

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
        private System.Windows.Forms.Label lblImageUrl;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancel;
    }
}