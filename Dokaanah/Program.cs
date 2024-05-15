using Dokaanah.Models;
using Dokaanah.Repositories.RepoClasses;
using Dokaanah.Repositories.RepoInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dokaanah
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Dokkanah2Contex>(options =>
            {
                options.
                UseSqlServer("Server=DESKTOP-0HPU58A\\SQLEXPRESS;Database=DokkanahDataBase_2fff;Encrypt=false;Trusted_Connection=True; TrustServerCertificate=True");
            });
            builder.Services.AddScoped<ICartRepo, CartRepo>();
            builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
            builder.Services.AddScoped<ICustomersRepo, CustomersRepo>();
            builder.Services.AddScoped<IPaymentRepo, PaymentsRepo>();
            builder.Services.AddScoped<ISellersRepo, SellersRepo>();
            builder.Services.AddScoped<IOrdersRepo, OrdersRepo>();
            builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
            builder.Services.AddScoped<IProduct_CategoryRepo, Product_CategoryRepo>();

            builder.Services.AddIdentity<Customer, IdentityRole>(con =>
            {
                con.Password.RequireNonAlphanumeric=true;

            }) .AddEntityFrameworkStores<Dokkanah2Contex>();



			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
