using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.BusinessFactories.Implementations;
using BusinessLogicLayer.BusinessFactories.Interfaces;
using ITHootUniversity.WebAppFactories.Interfaces;
using ITHootUniversity.WebAppFactories.Implementations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<UniversityDbContext>();

builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ILessonsRepository, LessonsRepository>();
builder.Services.AddScoped<IUsersInLessonsRepository, UsersInLessonsRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();

builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<ILessonsService, LessonsService>();
builder.Services.AddTransient<IUsersInLessonsService, UsersInLessonsService>();
builder.Services.AddTransient<IResultBuilderService, ResultBuilderService>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<ICabinetViewModelFactory, CabinetViewModelFactory>();

builder.Services.AddTransient<IModelToDtoFactory, ModelToDtoFactory>();
builder.Services.AddTransient<IDtoToModelFactory, DtoToModelFactory>();
builder.Services.AddTransient<IViewModelToDtoFactory, ViewModelToDtoFactory>();
builder.Services.AddTransient<IDtoToViewModelFactory, DtoToViewModelFactory>();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
