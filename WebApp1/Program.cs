using Microsoft.EntityFrameworkCore;
using WebApp1.Code;
using WebApp1.Data;

namespace WebApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conSqlServer = builder.Configuration.GetConnectionString("ConSqlServer");
            var conSqlite = builder.Configuration.GetConnectionString("ConSqlite");
            builder.Services.AddDbContext<BigStoreContext>(
                options => options.UseSqlite(conSqlite));
            //options => options.UseSqlServer(conSqlServer));

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IBrandHelper, BrandHelper>();
            builder.Services.AddScoped<ICategoryHelper, CategoryHelper>();

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