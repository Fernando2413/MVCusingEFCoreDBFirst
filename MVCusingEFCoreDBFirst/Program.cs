using Microsoft.EntityFrameworkCore;
using MVCusingEFCoreDBFirst.Models;
namespace MVCusingEFCoreDBFirst
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			// Add services to the container.
			builder.Services.AddControllersWithViews();
			//Adding DBContext Service
			builder.Services.AddDbContext<CompanyContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
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
