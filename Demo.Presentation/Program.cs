using Demo.BusinessLogic.Profiles;
using Demo.BusinessLogic.Services;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

            });

            builder.Services.AddAutoMapper(op => op.AddProfile(new MapingProfile()));
            builder.Services.AddScoped<IEmployeeRepositry, EmployeeRepositry>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var db = services.GetRequiredService<ApplicationDbContext>();

                db.Database.Migrate(); // Creates DB + Apply Migrations
            }

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
