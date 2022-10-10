using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using oef8_WebAppMVCClientLocationEFCore.Controllers;
using oef8_WebAppMVCClientLocationEFCore.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var sb = new StringBuilder();

sb.Append("Server= (localdb)\\MSSQLLocalDB;");
sb.Append("Database = ClientLocationData;");
sb.Append("Trusted_Connection = True;");
sb.Append("MultipleActiveResultSets = True");

var connString = sb.ToString();

builder.Services.AddDbContext<ClientLocationContext>
    (options => options.UseSqlServer(connString));





// Add services to the container.
builder.Services.AddControllersWithViews();

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
