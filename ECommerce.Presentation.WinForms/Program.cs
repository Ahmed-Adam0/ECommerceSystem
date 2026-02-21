using System;
using System.Windows.Forms;
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Presentation.WinForms.Forms;
using ECommerce.Presentation.WinForms.Forms.MainForm;

namespace ECommerce.Presentation.WinForms
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();


            //var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
            //Application.Run(loginForm);
            var productService = ServiceProvider.GetRequiredService<IProductService>();
            var categoryService = ServiceProvider.GetRequiredService<ICategoryService>();
            var cartItemService = ServiceProvider.GetRequiredService<ICartItemService>();
            Application.Run(new MainForm(productService,categoryService, cartItemService));
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterForm>();
            services.AddTransient<AdminDashboardForm>();
            services.AddTransient<CustomerHomeForm>();
        }
    }
}