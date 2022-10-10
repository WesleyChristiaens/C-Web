using MyFirstRazorWebApplication.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();/* HTML paginas in WWWROOT folder gebruiken */
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();/*Omzetten van razor pages naar HTML */
Databank.StartDataBank();/* classe databank wordt opgestart */

app.Run();
