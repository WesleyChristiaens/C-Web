using MVC_sportstore.Models.Data;

namespace MVC_sportstore.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
                if (!context.Products.Any())
                {
                    foreach (var item in DefaultData.Products)
                    {
                        var product = new Product(item.Split(';'));
                        context.Products.Add(product);
                    }

                    context.SaveChanges();
                }
            }
        }


    }
}
