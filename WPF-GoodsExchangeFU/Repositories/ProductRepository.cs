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
        public Product? GetProduct(int proId)
        {
            _context = new();
           return  _context.Products.SingleOrDefault(p => p.ProductId == proId) ;
        }
        public void UpdateProduct(Product product)
        {
            _context = new GoodsExchangeFudbContext();
            _context.Products.Update(product);
            _context.SaveChanges();
        }


        public void RemoveProduct(Product product)
        {
            _context = new GoodsExchangeFudbContext();
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void CreateProduct(Product product)
        {
            _context = new GoodsExchangeFudbContext();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<ProductType> GetProductTypes()
        {
            _context = new GoodsExchangeFudbContext();
            return _context.ProductTypes.ToList();
        }

        public List<Product>? GetProductsByName(string text)
        {
            return _context.Products.Where(p => p.ProductName.Contains(text)).ToList();
        }
    }
}
