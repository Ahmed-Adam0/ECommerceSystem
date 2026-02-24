using ECommerce.ApplicationLayer.DTOs.LoginDtos;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Domain.Enums;
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

        private async Task InitializeWebView()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async();

            string pagePath = Path.Combine(Application.StartupPath, "UI", "login.html");
            webView.Source = new Uri(pagePath);

            webView.CoreWebView2.Settings.IsWebMessageEnabled = true;

            webView.CoreWebView2.WebMessageReceived += async (s, e) =>
            {
                try
                {
                    using var doc = JsonDocument.Parse(e.WebMessageAsJson);
                    var root = doc.RootElement;

                    if (!root.TryGetProperty("action", out var actionProp))
                        return;

                    var action = actionProp.GetString();

                    // ✅ فتح صفحة التسجيل
                    if (action == "openRegister")
                    {
                        var register = Program.ServiceProvider.GetRequiredService<RegisterForm>();
                        register.Show();
                        return;
                    }

                    // ✅ تسجيل الدخول
                    if (action == "login")
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
                            webView.CoreWebView2.PostWebMessageAsJson(
                                JsonSerializer.Serialize(new
                                {
                                    action = "loginSuccess",
                                    message = $"Welcome back {user.FullName} 👋"
                                })
                            );

                            await Task.Delay(1500);

                            this.Hide();

                            if (user.Role == UserRole.Admin)
                            {
                                var adminForm = Program.ServiceProvider.GetRequiredService<AdminDashboardForm>();
                                adminForm.ShowDialog();
                            }
                            else
                            {
                                var customerForm = Program.ServiceProvider.GetRequiredService<MainForm>();

                                // 🚀 هنا نحدد الـ current user
                                customerForm.SetUser(user.Id); // user.Id من الـ UserDto اللي رجع من Login

                                customerForm.ShowDialog();
                            }
                        }
                        else
                        {
                            webView.CoreWebView2.PostWebMessageAsJson(
                                JsonSerializer.Serialize(new
                                {
                                    action = "loginError",
                                    message = "Invalid email or password"
                                })
                            );
                        }
                    }
                }
                catch
                {
                    // optional logging
                }
            };
        }
    }
}