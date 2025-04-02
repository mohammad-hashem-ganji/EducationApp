using App.Domain.AppServices;
using App.Domain.Core.Interfaces.AppServices;
using App.Domain.Core.Interfaces.Repo;
using App.Domain.Core.Interfaces.Services;
using App.Domain.Core.Interfaces.UOf;
using App.Domain.Services;
using App.Infra.DataAccess.Repo.Repos;
using App.Infra.DataAccess.Repo.SeedData;
using App.Infra.DataAccess.Repo.Uof;
using App.Infra.DB.SqlServer.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EducationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IEducationDistrictRepository, EducationDistrictRepository>();

builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IEducationDistrictService, EducationDistrictService>();
builder.Services.AddSingleton<IHostedService, CityNameUpdaterService>();

builder.Services.AddScoped<IProvinceAppService, ProvinceAppService>();
builder.Services.AddScoped<ICityAppService, CityAppService>();
builder.Services.AddScoped<IEducationDistrictAppService, EducationDistrictAppService>();
builder.Services.AddControllersWithViews();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EducationDbContext>();
    new DatabaseSeeder(dbContext).Seed();
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
    pattern: "{controller=EducationDistrict}/{action=GetEducationDistrictDetails}/{id?}");

app.Run();
