using Repositories;
using Repositories.Entities;

namespace Services
{
    public class ProductService
    {
        private ProductRepository _repo = new();

        public List<Product> LoadWaitingProductList()
        {
            return _repo.GetProducts().Where(p => p.Status == 3).ToList();
            
        }

        public void ModAcceptProduct(Product product)
        {
            _repo.UpdateProduct(product);
        }

        public void ModDenyProduct(Product product)
        {
            _repo.UpdateProduct(product);
        }
        public void RemoveProduct(int productId)
        {
            var product = _repo.GetProduct(productId);
            if (product != null)
            {
                product.Status = 0;
                _repo.UpdateProduct(product);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
