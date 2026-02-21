using System;
using System.Windows.Forms;
using ECommerce.ApplicationLayer.DTOs.LoginDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Presentation.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;

        public LoginForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;

            linkRegister.LinkClicked += linkRegister_LinkClicked;
        }

        

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = Program.ServiceProvider.GetRequiredService<RegisterForm>();
            registerForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            var dto = new LoginDto
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            var user = _userService.Login(dto);

            if (user == null)
            {
                MessageBox.Show("Invalid Email or Password");
                return;
            }

            MessageBox.Show("Welcome " + user.FullName);
            this.Hide();

            if (user.Role == UserRole.Admin)
            {
                var adminForm = Program.ServiceProvider.GetRequiredService<AdminDashboardForm>();
                adminForm.ShowDialog();
            }
            else
            {
                var customerForm = Program.ServiceProvider.GetRequiredService<CustomerHomeForm>();
                customerForm.ShowDialog();
            }

            this.Show();
        }
    }
}