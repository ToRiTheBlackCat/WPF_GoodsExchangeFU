using Repositories;
using Repositories.Entities;
using Repositories.Models;

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

        public List<ProductModels.ProductView>? GetProductsUI(string search, string order, int category, int from, int to)
        {
            //if (categories.Count() == 0)
            //    categories = new int[6] {1, 2,3, 4,5,6 };
            //var products = _repo.GetProducts().Where(p => p.Status == 1 && categories.Contains(p.TypeId));
            int[] categories = [category];
            if (category == 0)
                categories = [1, 2, 3, 4, 5, 6];

            var products = _repo.GetProducts().Where(p => p.Status == 1 && categories.Contains(p.TypeId)
                && p.ProductPrice >= from && p.ProductPrice <= to
                && (p.ProductName.ToLower().Contains(search.ToLower()) || p.ProductDescription.ToLower().Contains(search.ToLower())));
            if (!products.Any())
                return null;

            switch (order)
            {
                case "name":
                    products = products.OrderBy(p => p.ProductName);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.ProductName);
                    break;
                case "price":
                    products = products.OrderBy(p => p.ProductPrice);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.ProductPrice);
                    break;
                default:
                    break;
            }

            return products.Select(p => new ProductModels.ProductView()
            {
                ProductId = p.ProductId,
                ProductDescription = p.ProductDescription,
                ProductName = p.ProductName,
                ProductImage = p.ProductImage,
                ProductPrice = p.ProductPrice,
                TypeName = p.Type.TypeName,
                UserName = p.User.UserName,
            }).ToList();
        }

        public void RemoveProductUI(int productId)
        {
            var deleteProduct = _repo.GetProducts().FirstOrDefault(p => p.ProductId == productId);
            if (deleteProduct != null)
            {
                _repo.RemoveProduct(deleteProduct);
                return;
            }
            throw new Exception("Product not found!");
        }

        public void CreateProductUI(Product product)
        {
            _repo.CreateProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            var updateProduct = _repo.GetProducts().FirstOrDefault(p => p.ProductId == product.ProductId);
            if (updateProduct != null)
            {
                _repo.UpdateProduct(product);
                return;
            }
            throw new Exception("Product not found!");
        }

        public Product? GetProduct(int productId)
        {
            return _repo.GetProducts().FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Product>? GetProductsByUser(int userId)
        {
            var products = _repo.GetProducts().Where(p => p.UserId == userId && p.Status == 1).ToList();
            return products;
        }

        public List<ProductType> GetProductTypesUI()
        {
            return _repo.GetProductTypes();
        }

        public List<Product>? GetProductsByName(string text)
        {
            return _repo.GetProductsByName(text);
        }
    }
}
