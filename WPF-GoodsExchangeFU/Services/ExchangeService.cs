using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ExchangeService
    {
        private ExchangeRepo _repo = new ExchangeRepo();

        public void MakeExchangeUI(string userName, int wantId, int ownId, int balance) 
        {
            ProductService productService= new ProductService();
            UserService userService= new UserService();

            var user = userService.GetUserByName(userName);
            if (user == null) throw new Exception("Could not find user");

            var wantProduct = productService.GetProduct(wantId);
            if (wantProduct == null || wantProduct.Status != 1) throw new Exception("Could not find the product you want");

            var ownProduct = productService.GetProduct(ownId);
            if (ownProduct == null || ownProduct.Status != 1) throw new Exception("Could not find your Product");

            if (user.UserId == wantProduct.UserId) throw new Exception("You already own this product");
            if(user.UserId != ownProduct.UserId) throw new Exception("You don't own this product to exchange");

            ownProduct.Status = 2;
            productService.UpdateProduct(ownProduct);
            _repo.CreateExchange(user.UserId, wantProduct.ProductId, ownProduct.ProductId, balance);
        }
    }
}
