using Microsoft.EntityFrameworkCore;
using MVCFifa2022.Data;
using System.Text;


/* Hardcoded connection string opbouwen */
var builder = WebApplication.CreateBuilder(args);
var sb = new StringBuilder();

sb.Append("Server= (localdb)\\MSSQLLocalDB;");
sb.Append("Database = fifa2022;");
sb.Append("Trusted_Connection = True;");
sb.Append("MultipleActiveResultSets = True");

var connString = sb.ToString();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(connString)); 

/* OPGELET!!!  .UseSqlServer zit in de nuget package Microsoft.EntityFrameWorkCore.SqlServer die ook zelf geinstalleerd moet worden.*/




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
