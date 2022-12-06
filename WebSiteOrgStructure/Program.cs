using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlyOrgStructure.Data;
using WebSiteOrgStructure.DI;

var builder = WebApplication.CreateBuilder(args);
var sqlConBuilder = new SqlConnectionStringBuilder();

builder.Services.AddControllersWithViews();
DI.CreateDI(builder.Services);
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");
builder.Services.AddDbContext<DbContextConfigurer>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
