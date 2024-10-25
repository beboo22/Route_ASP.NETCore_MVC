using LinkDev._1stproj.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using LinkDev._1stproj.DAL.Presistance.Repositories.DepartmentRep;
using LinkDev._1stProj.BLL.Services.DepartmentServ;
using LinkDev._1stproj.DAL.Presistance.Repositories.EmployeeRep;
using LinkDev._1stProj.BLL.Services.EmployeeServ;
using LinkDev._1stproj.DAL.Presistance.UnitofWork;
using LinkDev._1stProj.BLL.common.services.interfaces;
using LinkDev._1stProj.BLL.common.services.entity;
using Microsoft.AspNetCore.Identity;
using LinkDev._1stproj.DAL.Models.identity;

namespace LinkDev._1stProj.PL
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<_1stProjectDbContext>(options =>
																options.UseLazyLoadingProxies()
																.UseSqlServer(builder.
																					Configuration.
																					GetConnectionString("DefultConnection")));
			//builder.Services.AddScoped<IRepositoryDepartment, DepartmentRepository>();
			builder.Services.AddScoped<IServicesDepartment, DepartmentService>();
			//builder.Services.AddScoped<IRepositoryEmployee, EmployeeRepository>();
			builder.Services.AddScoped<IServicesEmployee, EmployeeService>();

			builder.Services.AddTransient<IUnitOfWork, UnitofWork>();
			builder.Services.AddTransient<IAttachmentServices, AttacmentService>();



			builder.Services.AddIdentity<User, Role>(options =>
			{
				options.Password.RequiredLength = 5;
				options.Password.RequireDigit = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
				options.Password.RequiredUniqueChars = 2;
				options.Password.RequireNonAlphanumeric = true;

				options.User.RequireUniqueEmail = true;

				options.Lockout.AllowedForNewUsers = true;
				options.Lockout.MaxFailedAccessAttempts = 10;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);

							


			}).AddEntityFrameworkStores<_1stProjectDbContext>().AddDefaultTokenProviders();

			//builder.Services.AddScoped<UserManager<User>>();
			//builder.Services.AddScoped<SignInManager<User>>();
			//builder.Services.AddScoped<RoleManager<User>>();


			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromMinutes(0.5); //  Token expires 
				options.LoginPath = "/Account/SignIn"; // if user authenticated
				options.AccessDeniedPath = "/Account/AccessDenied"; // if use bolked from website
				options.LogoutPath = "/Account/SignOut";
			});
			



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			builder.Services.AddAuthorization();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
