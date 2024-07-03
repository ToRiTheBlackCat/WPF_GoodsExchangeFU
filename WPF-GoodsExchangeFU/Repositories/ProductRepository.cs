using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories
{
    public class ProductRepository
    {
        GoodsExchangeFudbContext _context;

        public List<Product> GetProducts()
        {
            _context = new();
            return _context.Products.Include("Type").Include("User").ToList();
        }
        public Product GetProduct(int proId)
        {
            _context = new();
           return  _context.Products.SingleOrDefault(p => p.ProductId == proId) ;
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
