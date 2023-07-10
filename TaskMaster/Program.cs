using Microsoft.AspNetCore.Mvc;
using TaskMaster.Data;
using TaskMaster.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;


namespace TaskMaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSession();
            builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

            builder.Services.AddSingleton<IConfiguration>(configuration);


            string connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connectionString));

            //builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(@"Server=LAPTOP-B7IS3RHP\SQLEXPRESS01;Database=TaskMaster;TrustServerCertificate=Yes;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //builder.Services.AddIdentity<IdentityUser,  IdentityRole>().AddEntityFrameworkStores<AppDBContent>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<IAccounts, AccountRepository>();//Интерфейс реализуется в репозиториях
            builder.Services.AddTransient<ITasks, TaskRepository>();
            builder.Services.AddTransient<ISolutions, SolutionRepository>();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var app = builder.Build();
            app.UseSession();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            

            
            
            app.Run();
        }
    }
}