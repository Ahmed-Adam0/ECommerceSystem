using ECommerce.ApplicationLayer.DTOs.CartItemDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repositories;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace ECommerce.Presentation.WinForms.Forms
{

    public partial class MainForm : Form
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICartItemService _cartItemService;
        private int _currentUserId;

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
        }
        public void SetUser(int userId)
        {
            _currentUserId = userId;
        }
        private void InitializeComponent()
        {
            this.Text = "Home";
            this.Width = 1200;
            this.Height = 800;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await InitWebView();
        }
        // =========================
        // WebView Init
        // =========================
        private async Task InitWebView()
        {
            webView = new WebView2 { Dock = DockStyle.Fill };
            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async();

            webView.CoreWebView2.WebMessageReceived -= WebMessageReceived; // مهم
            webView.CoreWebView2.WebMessageReceived += WebMessageReceived;

            //webView.CoreWebView2.NavigationCompleted += WebView_NavigationCompleted;

            string htmlPath = Path.Combine(Application.StartupPath, "UI", "mainform.html");
            webView.Source = new Uri(htmlPath);

            // استنى الصفحة تفتح قبل ارسال البيانات
            var tcs = new TaskCompletionSource();
            void Handler(object? s, CoreWebView2NavigationCompletedEventArgs e)
            {
                if (!e.IsSuccess) return;
                webView.CoreWebView2.NavigationCompleted -= Handler;
                tcs.SetResult();
            }
            webView.CoreWebView2.NavigationCompleted += Handler;
            await tcs.Task;

            // بعد ما الصفحة تتحمل، ابعتي البيانات
            await SendHomePageData();
        }


        // =========================
        // After Page Load
        // =========================
        private async void WebView_NavigationCompleted(object? sender,
     CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess) return;

            if (webView.Source == null)
                return;

            if (!webView.Source.AbsolutePath.EndsWith("mainform.html"))
                return;

            await SendHomePageData();
        }

        // =========================
        // Send Home Data
        // =========================
        private async Task SendHomePageData()
        {

            int cartCount = await _cartItemService.GetUserCartCountAsync(_currentUserId);

            var allProductsList = await _productService.GetAllProductsAsync();

            var products = allProductsList
            .Take(10)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.MainImageUrl,
                    HoverImageUrl = p.ImageUrls.FirstOrDefault(),
                    p.CategoryName,
                    p.Description
                }).ToList();

            var allProducts = allProductsList
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.MainImageUrl,
                    Images = p.ImageUrls,
                    p.Stock,
                    p.CategoryName,
                    p.Description
                }).ToList();

            var allCategories = _categoryService.GetAllCategories()
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.ImageUrl,
                    c.ProductCount
                }).ToList();

            var data = new
            {
                products,
                categories = allCategories.Take(4),
                allProducts,
                allCategories,
                 cartCount
            };

            var json = JsonSerializer.Serialize(new
            {
                action = "homeData",
                data
            });

            webView.CoreWebView2.PostWebMessageAsJson(json);
        }

        private async Task HandleAddToCart(JsonElement root)
        {
            int productId = root.GetProperty("productId").GetInt32();
            int quantityRequested =
                root.TryGetProperty("quantity", out var qtyProp)
                    ? qtyProp.GetInt32()
                    : 1;

            int userId = _currentUserId;

            // 1️⃣ هات المنتج
            var product = _productService.GetProductById(productId);
            if (product == null || product.Stock <= 0)
                return; // مفيش منتج أو مفيش ستوك

            // 2️⃣ هات العنصر من الكارت لو موجود
            var existingItem = await _cartItemService.GetCartItemAsync(userId, productId);

            // 3️⃣ احسب الكمية المسموح إضافتها (مينفعش أكتر من الستوك)
            int quantityToAdd = Math.Min(quantityRequested, product.Stock);
            if (quantityToAdd <= 0)
                return;

            if (existingItem != null)
            {
                // المنتج موجود في الكارت
                existingItem.Quantity += quantityToAdd;

                _cartItemService.UpdateCartItem(new UpdateCartItemDto
                {
                    Id = existingItem.Id,
                    Quantity = existingItem.Quantity
                });
            }
            else
            {
                // منتج جديد في الكارت
                await _cartItemService.CreateCartItemAsync(userId, new CreateCartItemDto
                {
                    ProductId = productId,
                    Quantity = quantityToAdd
                });
            }

            // 4️⃣ خصم الكمية من الستوك الحقيقي
            product.Stock -= quantityToAdd;

            _productService.UpdateProduct(new UpdateProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Stock = product.Stock
            });

            // 5️⃣ حفظ التغييرات
            await _cartItemService.SaveChangesAsync();
            await _productService.SaveChangesAsync();

            // 6️⃣ تحديث بيانات الهوم (products + cart count)
            await SendHomePageData();

            // 7️⃣ تحديث عداد الكارت
            int cartCount = await _cartItemService.GetUserCartCountAsync(userId);
            webView.CoreWebView2.PostWebMessageAsJson(
                JsonSerializer.Serialize(new
                {
                    action = "updateCartCount",
                    count = cartCount
                })
            );

            // 8️⃣ تحديث الستوك فورًا في صفحة الـ single product
            webView.CoreWebView2.PostWebMessageAsJson(
                JsonSerializer.Serialize(new
                {
                    action = "updateProductStock",
                    productId = product.Id,
                    stock = product.Stock
                })
            );
        }

        private async Task OpenCartPage()
        {
            int userId = _currentUserId;

            string cartPath = Path.Combine(Application.StartupPath, "UI", "cart.html");

            var tcs = new TaskCompletionSource();

            void Handler(object? s, CoreWebView2NavigationCompletedEventArgs e)
            {
                if (!e.IsSuccess) return;

                webView.CoreWebView2.NavigationCompleted -= Handler;
                tcs.SetResult();
            }

            webView.CoreWebView2.NavigationCompleted += Handler;
            webView.Source = new Uri(cartPath);

            await tcs.Task; // 👈 استنى الصفحة تفتح فعليًا

            await SendCartData(userId);
        }

        private async Task SendCartData(int userId)
        {
            var cartItems = await _cartItemService.GetUserCartAsync(userId);
            var allProductsList = await _productService.GetAllProductsAsync();
            int cartCount = await _cartItemService.GetUserCartCountAsync(userId);


            var data = new
            {
                action = "openCart",
                cartItems = cartItems.Select(c => new
                {
                    c.ProductId,
                    c.Product.Name,
                    c.Product.Price,
                    c.Quantity,
                    c.Product.ImageUrl
                }),
                allProducts = allProductsList.Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.MainImageUrl,
                    p.CategoryName
                }),
                cartCount
            };


            webView.CoreWebView2.PostWebMessageAsJson(JsonSerializer.Serialize(data));
        }
        // =========================
        // Receive Messages
        // =========================


        private async void WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            using var doc = JsonDocument.Parse(e.WebMessageAsJson);
            var root = doc.RootElement;

            if (!root.TryGetProperty("action", out var actionProp))
                return;

            string action = actionProp.GetString() ?? "";
            //MessageBox.Show($"Action received: {action}"); // 👈 اختبار

            switch (action)
            {
                case "navigate":
                    HandleNavigation(root);
                    break;

                case "viewProduct":
                    HandleViewProduct(root);
                    break;

                case "addToCart":
                    await HandleAddToCart(root);
                    break;

                case "openCart":
                    await OpenCartPage();
                    break;

                case "changeQuantity":
                    await HandleChangeQuantity(root);
                    break;

                case "removeFromCart":
                    await HandleRemoveFromCart(root);
                    break;

                default:
                    break;
            }
        }


        private async Task HandleChangeQuantity(JsonElement root)
        {
            int productId = root.GetProperty("productId").GetInt32();
            int delta = root.GetProperty("delta").GetInt32();

            var product = _productService.GetProductById(productId);
            if (product == null)
                return;

            var cartItem = await _cartItemService.GetCartItemAsync(_currentUserId, productId);
            if (cartItem == null)
                return;

            // لو زيادة
            if (delta > 0)
            {
                if (product.Stock <= 0)
                    return; // مفيش ستوك أصلاً

                cartItem.Quantity += 1;
                product.Stock -= 1;
            }
            // لو نقصان
            else if (delta < 0)
            {
                if (cartItem.Quantity <= 1)
                    return; // أقل كمية 1

                cartItem.Quantity -= 1;
                product.Stock += 1;
            }

            _cartItemService.UpdateCartItem(new UpdateCartItemDto
            {
                Id = cartItem.Id,
                Quantity = cartItem.Quantity
            });

            _productService.UpdateProduct(new UpdateProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Stock = product.Stock
            });

            await _cartItemService.SaveChangesAsync();
            await _productService.SaveChangesAsync();

            await SendCartData(_currentUserId);
        }
        private async Task HandleRemoveFromCart(JsonElement root)
        {
            int productId = root.GetProperty("productId").GetInt32();

            var cartItem = await _cartItemService.GetCartItemAsync(_currentUserId, productId);
            if (cartItem == null)
                return;

            var product = _productService.GetProductById(productId);
            if (product != null)
            {
                product.Stock += cartItem.Quantity;

                _productService.UpdateProduct(new UpdateProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Stock = product.Stock
                });
            }

            await _cartItemService.RemoveFromCartAsync(_currentUserId, productId);

            await _productService.SaveChangesAsync();
           await _cartItemService.SaveChangesAsync();

            await SendCartData(_currentUserId);
        }
        // =========================
        // Navigation
        // =========================
        private async void HandleNavigation(JsonElement root)
        {
            if (!root.TryGetProperty("page", out var pageProp))
                return;

            string page = pageProp.GetString() ?? "";
            string path = Path.Combine(Application.StartupPath, "UI", page);

            if (!File.Exists(path))
                return;

            void Handler(object? s, CoreWebView2NavigationCompletedEventArgs e)
            {
                if (!e.IsSuccess) return;

                webView.CoreWebView2.NavigationCompleted -= Handler;

                // 👈 لو رجعنا للهوم ابعتي الداتا تاني
                if (page == "mainform.html")
                {
                    _ = SendHomePageData();
                }
            }

            webView.CoreWebView2.NavigationCompleted += Handler;
            webView.Source = new Uri(path);
        }


        private async void HandleViewProduct(JsonElement root)
        {
            if (!root.TryGetProperty("productId", out var idProp))
                return;

            int productId = idProp.GetInt32();
            var product = _productService.GetProductById(productId);
            if (product == null)
                return;

            var allProducts = await _productService.GetAllProductsAsync();
            int cartCount = await _cartItemService.GetUserCartCountAsync(_currentUserId);

            string singlePath = Path.Combine(Application.StartupPath, "UI", "single-product.html");

            async Task SendData()
            {
                var json = JsonSerializer.Serialize(new
                {
                    action = "displayProductDetails",
                    product = new
                    {
                        product.Id,
                        product.Name,
                        product.Price,
                        product.Description,
                        product.Stock,
                        product.CategoryName,
                        MainImageUrl = product.MainImageUrl,
                        Images = product.ImageUrls
                    },
                    allProducts = allProducts.Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Price,
                        p.MainImageUrl,
                        p.CategoryName
                    }),
                    cartCount // ✅ ابعت الكارت count فورًا
                });

                webView.CoreWebView2.PostWebMessageAsJson(json);
            }

            // لو أنا بالفعل في صفحة single-product → ابعتي الداتا فورًا
            if (webView.Source != null &&
                webView.Source.AbsolutePath.EndsWith("single-product.html"))
            {
                await SendData();
                return;
            }

            // لو أنا في الهوم → روح للسينجل أولاً ثم ابعتي الداتا
            void Handler(object? s, CoreWebView2NavigationCompletedEventArgs e)
            {
                if (!e.IsSuccess) return;

                _ = SendData(); // ابعتي البيانات بعد التنقل
                webView.CoreWebView2.NavigationCompleted -= Handler;
            }

            webView.CoreWebView2.NavigationCompleted += Handler;
            webView.Source = new Uri(singlePath);
        }
        private void SendProductToPage(dynamic product)
        {
            var json = JsonSerializer.Serialize(new
            {
                action = "displayProductDetails",
                product = new
                {
                    product.Id,
                    product.Name,
                    product.Price,
                    product.Description,
                    product.Stock,
                    product.CategoryName,
                    MainImageUrl = product.MainImageUrl,
                    Images = product.ImageUrls
                }
            });

            webView.CoreWebView2.PostWebMessageAsJson(json);
        }
        // =========================
        // View Product
        // =========================
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

    }
}