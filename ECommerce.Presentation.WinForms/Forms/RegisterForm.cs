using System;
using System.Windows.Forms;
using ECommerce.ApplicationLayer.DTOs.UserDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.ApplicationLayer.Services;

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

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            try
            {
                var dto = new CreateUserDto
                {
                    FullName = txtFullName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text
                };

                var user = _userService.CreateCustomer(dto);

                MessageBox.Show("Account Created Successfully for " + user.FullName);
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