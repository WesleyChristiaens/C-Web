using MVC_sportstore.Data;
using MVC_sportstore.Models.Data;

namespace MVC_sportstore.Models
{
    public class ProductRepository
    {
        private StoreDbContext _context;



        // ! Opgelet dit is geen dependency injection - Geen controller class
        public ProductRepository(StoreDbContext context)
        {
            this._context = context;
        }

        private IEnumerable<Product> GetProducts(int productPage, string category)
        {
            return _context.Products
                .Where(p => (category == null) || (category == p.Category) )   
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PagingSettings.ProductPagination)
                .Take(PagingSettings.ProductPagination);
        }


        private PagingInfo GetPagingInfo(int productPage, string category)
        {
            var pagingInfo = new PagingInfo();

            pagingInfo.CurrentPage = productPage;
            pagingInfo.ItemsPerPage = PagingSettings.ProductPagination;
            pagingInfo.TotalItems = (category == null) ? _context.Products.Count(): _context.Products.Where(e => e.Category == category).Count();

            return pagingInfo;
        }

        public ProductModel GetProductModel(int productPage, string category)
        {
            var productModel = new ProductModel();

            productModel.Products = GetProducts(productPage, category);
            productModel.PagingInfo = GetPagingInfo(productPage, category);

            return productModel;
        }
    }
}

