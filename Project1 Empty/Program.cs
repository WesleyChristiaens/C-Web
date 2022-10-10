var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();


/*app.MapGet("/", () => "Hello World!");*/

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();