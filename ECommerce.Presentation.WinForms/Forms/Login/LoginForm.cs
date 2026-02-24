using ECommerce.ApplicationLayer.DTOs.LoginDtos;
using ECommerce.ApplicationLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

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
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async();

            string pagePath = Path.Combine(Application.StartupPath, "UI", "login.html");
            webView.Source = new Uri(pagePath);

            webView.CoreWebView2.WebMessageReceived += async (s, e) =>
            {
                var root = JsonDocument.Parse(e.WebMessageAsJson).RootElement;

                if (root.GetProperty("action").GetString() == "login")
                {
                    string email = root.GetProperty("email").GetString();
                    string password = root.GetProperty("password").GetString();

                    var dto = new LoginDto
                    {
                        Email = email,
                        Password = password
                    };

                    var user = _userService.Login(dto);

                    if (user != null)
                    {
                        // ابعتي رسالة نجاح
                        webView.CoreWebView2.PostWebMessageAsJson(
                            JsonSerializer.Serialize(new
                            {
                                action = "loginSuccess",
                                message = $"Welcome back {user.FullName} 👋"
                            })
                        );

                        // استنى شوية وبعدين افتحي المين
                        await Task.Delay(1500);

                        var main = Program.ServiceProvider.GetRequiredService<MainForm>();
                        main.SetUser(user.Id);

                        this.Hide();
                        main.Show();
                    }
                    else
                    {
                        // ابعتي رسالة خطأ
                        webView.CoreWebView2.PostWebMessageAsJson(
                            JsonSerializer.Serialize(new
                            {
                                action = "loginError",
                                message = "Invalid email or password"
                            })
                        );
                    }
                }
            };
        }
    }
}