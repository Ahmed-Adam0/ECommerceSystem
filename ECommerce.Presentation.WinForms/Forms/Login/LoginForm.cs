using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ECommerce.ApplicationLayer.DTOs.LoginDtos;
using ECommerce.ApplicationLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.WinForms;

namespace ECommerce.Presentation.WinForms.Forms
{
    public class LoginForm : Form
    {
        private readonly IUserService _userService;
        private WebView2 webView;

        public LoginForm(IUserService userService)
        {
            _userService = userService;

            InitializeForm();
            InitializeWebView();
        }

        private void InitializeForm()
        {
            this.Text = "Login";
            this.WindowState = FormWindowState.Maximized;
        }

        private async void InitializeWebView()
        {
            webView = new WebView2 { Dock = DockStyle.Fill };
            this.Controls.Add(webView);

            // تأكد من WebView2 Runtime مثبت
            await webView.EnsureCoreWebView2Async();

            string pagePath = Path.Combine(Application.StartupPath, "UI", "login.html");

            // مؤقتًا للتأكد من المسار
            if (!File.Exists(pagePath))
            {
                MessageBox.Show($"Login HTML not found at: {pagePath}");
                return;
            }

            webView.Source = new Uri(pagePath);

            webView.CoreWebView2.WebMessageReceived += async (s, e) =>
            {
                var root = JsonDocument.Parse(e.WebMessageAsJson).RootElement;
                string action = root.GetProperty("action").GetString();

                if (action == "login")
                {
                    await HandleLogin(root);
                }
                else if (action == "goToRegister")
                {
                    await OpenRegisterForm();
                }
            };
        }

        private async Task HandleLogin(JsonElement root)
        {
            string email = root.GetProperty("email").GetString();
            string password = root.GetProperty("password").GetString();

            var dto = new LoginDto { Email = email, Password = password };
            var user = _userService.Login(dto);

            if (user != null)
            {
                Form targetForm;

                // ⚡ تحديد الفورم حسب الدور
                if (user.Role == Domain.Enums.UserRole.Admin)
                    targetForm = Program.ServiceProvider.GetRequiredService<AdminDashboardForm>();
                else
                    targetForm = Program.ServiceProvider.GetRequiredService<MainForm>();

                if (targetForm is MainForm mainForm)
                    mainForm.SetUser(user.Id);

                this.Hide();
                await Task.Delay(300);
                targetForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid email or password!");
            }
        }

        private async Task OpenRegisterForm()
        {
            var register = Program.ServiceProvider.GetRequiredService<RegisterForm>();
            this.Hide();
            register.ShowDialog();
            this.Show();
        }
    }
}