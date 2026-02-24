using ECommerce.ApplicationLayer.DTOs.UserDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Domain.Enums;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommerce.Presentation.WinForms.Forms
{
    public class RegisterForm : Form
    {
        private readonly IUserService _userService;
        private WebView2 webView;

        public RegisterForm(IUserService userService)
        {
            _userService = userService;

            Text = "Register";
            WindowState = FormWindowState.Maximized;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await InitializeWebView();
        }

        private async Task InitializeWebView()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(webView);

            await webView.EnsureCoreWebView2Async();
            MessageBox.Show("WebView2 جاهز!");
            if (webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Settings.IsWebMessageEnabled = true;
                webView.CoreWebView2.WebMessageReceived += WebMessageReceived;
            }
            string pagePath = Path.Combine(Application.StartupPath, "UI", "register.html");

            if (!File.Exists(pagePath))
            {
                MessageBox.Show("register.html not found:\n" + pagePath);
                return;
            }

             webView.CoreWebView2.Navigate(new Uri(pagePath).AbsoluteUri);
        }

        private async void WebMessageReceived(object? sender,
            Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            MessageBox.Show("Message Received"); // للتأكد إن الحدث اشتغل

            using var doc = JsonDocument.Parse(e.WebMessageAsJson);
            var root = doc.RootElement;

            if (!root.TryGetProperty("action", out var actionProp))
                return;

            if (actionProp.GetString() != "register")
                return;

            string fullName = root.GetProperty("fullName").GetString();
            string email = root.GetProperty("email").GetString();
            string password = root.GetProperty("password").GetString();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                SendPopup("All fields are required", "error");
                return;
            }

            if (password.Length < 8)
            {
                SendPopup("Password must be at least 8 characters", "error");
                return;
            }

            try
            {
                var dto = new CreateUserDto
                {
                    FullName = fullName,
                    Email = email,
                    Password = password,
                    Role = UserRole.Customer
                };

                _userService.CreateCustomer(dto);

                SendPopup("Account created successfully 🎉", "success");

                await Task.Delay(1500);
                Close();
            }
            catch (Exception ex)
            {
                SendPopup(ex.Message, "error");
            }
        }

        private void SendPopup(string message, string type)
        {
            webView.CoreWebView2.PostWebMessageAsJson(
                JsonSerializer.Serialize(new
                {
                    action = "showPopup",
                    message,
                    type
                })
            );
        }
    }
}