using System;
using System.Windows.Forms; 
using ECommerce.ApplicationLayer.Interfaces;
using ECommerce.ApplicationLayer.Services;
using ECommerce.Infrastructure.Data; 
using ECommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Presentation.WinForms
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

       // [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            var mainForm = ServiceProvider.GetRequiredService<Form1>();
            System.Windows.Forms.Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<ApplicationDbContext>();

            // Generic Repository
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();

            // Forms
            services.AddTransient<Form1>();
        }
    }
}
