 using ECommerce.ApplicationLayer.DTOs.CartItemDtos;
using ECommerce.ApplicationLayer.DTOs.ProductDtos;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using ECommerce.Infrastructure.Repositories;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
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
        private readonly IOrderService _orderService; 
        private int _currentUserId;

        private WebView2 webView;

        public MainForm(
     IProductService productService,
     ICategoryService categoryService,
     ICartItemService cartItemService,
     IOrderService orderService) 
        {
            _productService = productService;
            _categoryService = categoryService;
            _cartItemService = cartItemService;
            _orderService = orderService;

            InitializeComponent();
        }
        public void SetUser(int userId)
        {
            _currentUserId = userId;
        }
        private void InitializeComponent()
        {
            this.Text = "Home";
            this.WindowState = FormWindowState.Maximized;
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await InitWebView();
        }
       
        private async Task InitWebView()
        {
            webView = new WebView2 { Dock = DockStyle.Fill };
            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async();

            webView.CoreWebView2.WebMessageReceived -= WebMessageReceived; 
            webView.CoreWebView2.WebMessageReceived += WebMessageReceived;


            string htmlPath = Path.Combine(Application.StartupPath, "UI", "mainform.html");
            webView.Source = new Uri(htmlPath);

            var tcs = new TaskCompletionSource();
            void Handler(object? s, CoreWebView2NavigationCompletedEventArgs e)
            {
                if (!e.IsSuccess) return;
                webView.CoreWebView2.NavigationCompleted -= Handler;
                tcs.SetResult();
            }
            webView.CoreWebView2.NavigationCompleted += Handler;
            await tcs.Task;

            await SendHomePageData();
        }


       
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

            var product = _productService.GetProductById(productId);
            if (product == null || product.Stock <= 0)
                return; 
            var existingItem = await _cartItemService.GetCartItemAsync(userId, productId);

            int quantityToAdd = Math.Min(quantityRequested, product.Stock);
            if (quantityToAdd <= 0)
                return;

            if (existingItem != null)
            {
                existingItem.Quantity += quantityToAdd;

                _cartItemService.UpdateCartItem(new UpdateCartItemDto
                {
                    Id = existingItem.Id,
                    Quantity = existingItem.Quantity
                });
            }
            else
            {
                await _cartItemService.CreateCartItemAsync(userId, new CreateCartItemDto
                {
                    ProductId = productId,
                    Quantity = quantityToAdd
                });
            }

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

            await _cartItemService.SaveChangesAsync();
            await _productService.SaveChangesAsync();

            await SendHomePageData();

            int cartCount = await _cartItemService.GetUserCartCountAsync(userId);
            webView.CoreWebView2.PostWebMessageAsJson(
                JsonSerializer.Serialize(new
                {
                    action = "updateCartCount",
                    count = cartCount
                })
            );

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

            await tcs.Task; 

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
      

        private async void WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            using var doc = JsonDocument.Parse(e.WebMessageAsJson);
            var root = doc.RootElement;

            if (!root.TryGetProperty("action", out var actionProp))
                return;

            string action = actionProp.GetString() ?? "";

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

                case "openOrder":   
                    await OpenOrderPage(root);
                    break;

                case "createOrder":
                    await HandleCreateOrder();
                    break;

                case "cancelOrder":
                    await HandleCancelOrder(root);
                    break;

                case "orderPageReady":
                    await SendOrderData(_currentUserId);
                    break;

                default:
                    break;
            }
        }


        private async Task HandleCancelOrder(JsonElement root)
        {
            int orderId = root.GetProperty("orderId").GetInt32();
            var order = _orderService.GetOrderById(orderId);

            if (order == null || order.Status == OrderStatus.Shipping)
                return;

            _orderService.DeleteOrder(orderId);
            await _orderService.SaveChangesAsync();

            var orders = _orderService.GetOrdersByUserId(_currentUserId);
            webView.CoreWebView2.PostWebMessageAsJson(
                JsonSerializer.Serialize(new
                {
                    action = "renderOrders",
                    orders = orders.Select(o => new
                    {
                        o.Id,
                        Status = o.Status.ToString(),
                        o.TotalPrice
                    })
                })
            );
        }

        private async Task HandleCreateOrder()
        {
            int userId = _currentUserId;

            var cartItems = await _cartItemService.GetUserCartAsync(userId);
            if (!cartItems.Any()) return;

            var order = new Order
            {
                UserId = userId,
                Status = OrderStatus.Pending,
                OrderDate = DateTime.Now,
                TotalPrice = cartItems.Sum(c => c.Product.Price * c.Quantity)
            };

            await _orderService.CreateOrderAsync(order);

            foreach (var item in cartItems)
                await _cartItemService.RemoveFromCartAsync(userId, item.ProductId);
            await _cartItemService.SaveChangesAsync();

            string orderPath = Path.Combine(Application.StartupPath, "UI", "order.html");

            var tcs = new TaskCompletionSource();
            void Handler(object? s, CoreWebView2NavigationCompletedEventArgs e)
            {
                if (!e.IsSuccess) return;

                webView.CoreWebView2.NavigationCompleted -= Handler;
                tcs.SetResult();
            }

            webView.CoreWebView2.NavigationCompleted += Handler;
            webView.Source = new Uri(orderPath);
            await tcs.Task; 
            var orders = _orderService.GetOrdersByUserId(userId);

            webView.CoreWebView2.PostWebMessageAsJson(
                JsonSerializer.Serialize(new
                {
                    action = "renderOrders",
                    orders = orders.Select(o => new
                    {
                        o.Id,
                        Status = o.Status.ToString(),
                        o.TotalPrice,
                        OrderDate = o.OrderDate.ToString("yyyy-MM-dd")
                    })
                })
            );
        }
        private async Task OpenOrderPage(JsonElement root)
        {
            int userId = _currentUserId;

            string orderPath = Path.Combine(Application.StartupPath, "UI", "order.html");

            var tcs = new TaskCompletionSource();

            void Handler(object? s, CoreWebView2NavigationCompletedEventArgs e)
            {
                if (!e.IsSuccess) return;

                webView.CoreWebView2.NavigationCompleted -= Handler;
                tcs.SetResult();
            }

            webView.CoreWebView2.NavigationCompleted += Handler;
            webView.Source = new Uri(orderPath);

            await tcs.Task; 

            await SendOrderData(userId);
        }
        private async Task SendOrderData(int userId)
        {
            var orders = _orderService.GetOrdersByUserId(userId);

            webView.CoreWebView2.PostWebMessageAsJson(
                JsonSerializer.Serialize(new
                {
                    action = "renderOrders",
                    orders = orders.Select(o => new
                    {
                        o.Id,
                        Status = o.Status.ToString(),
                        o.TotalPrice
                    })
                })
            );
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

            if (delta > 0)
            {
                if (product.Stock <= 0)
                    return; 

                cartItem.Quantity += 1;
                product.Stock -= 1;
            }
            else if (delta < 0)
            {
                if (cartItem.Quantity <= 1)
                    return; 

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
                    cartCount 
                });

                webView.CoreWebView2.PostWebMessageAsJson(json);
            }

            if (webView.Source != null &&
                webView.Source.AbsolutePath.EndsWith("single-product.html"))
            {
                await SendData();
                return;
            }

            void Handler(object? s, CoreWebView2NavigationCompletedEventArgs e)
            {
                if (!e.IsSuccess) return;

                _ = SendData(); 
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
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

    }
}