using MVC_sportstore.Models.Data;

namespace MVC_sportstore.Models
{
    public class ProductModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
