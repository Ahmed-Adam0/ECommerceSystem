using System;
using System.Windows.Forms;
using ECommerce.ApplicationLayer.DTOs.UserDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Domain.Enums;

namespace ECommerce.Presentation.WinForms.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly IUserService _userService;

        public RegisterForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var fullName = txtFullName.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required");
                return;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                MessageBox.Show("Invalid email format");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters");
                return;
            }

            var dto = new CreateUserDto
            {
                FullName = fullName,
                Email = email,
                Password = password,
                Role = UserRole.Customer
            };

            try
            {
                _userService.CreateCustomer(dto);

                MessageBox.Show("Account Created Successfully");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}