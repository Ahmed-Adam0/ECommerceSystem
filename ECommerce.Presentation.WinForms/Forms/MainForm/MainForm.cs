using ECommerce.ApplicationLayer.Services;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace ECommerce.Presentation.WinForms.Forms.MainForm
{
    public partial class MainForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICartItemService _cartItemService;

        private WebView2 webView;

        public MainForm(
            IProductService productService,
            ICategoryService categoryService,
            ICartItemService cartItemService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _cartItemService = cartItemService;

            InitializeComponent();
            InitWebView();
        }

        private void InitializeComponent()
        {
            this.Text = "Home";
            this.Width = 1200;
            this.Height = 800;
        }

        private async void InitWebView()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async();

            // افتحي DevTools علشان نشوف الـ Console
            webView.CoreWebView2.OpenDevToolsWindow();

            string htmlPath = Path.Combine(
                Application.StartupPath,
                "UI",
                "mainform.html");

            webView.Source = new Uri(htmlPath);

            // IMPORTANT: ابعتي الداتا بعد ما الصفحة تخلص تحميل
            webView.CoreWebView2.NavigationCompleted += WebView_NavigationCompleted;
        }

        private void WebView_NavigationCompleted(object? sender, EventArgs e)
        {
            var products = _productService.GetAllProducts()
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    p.ImageUrl
                })
                .ToList();

            var categories = _categoryService.GetAllCategories()
                .Take(10)
                .Select(c => new
                {
                    c.Name,
                    c.ImageUrl
                })
                .ToList();

            var data = new
            {
                products = products,
                categories = categories
            };

            string json = JsonSerializer.Serialize(data);

            webView.CoreWebView2.PostWebMessageAsString(json);
        }
    }
}