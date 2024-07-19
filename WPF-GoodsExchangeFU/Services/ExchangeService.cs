using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repositories.Models.ExchangeModel;

namespace Services
{
    public class ExchangeService
    {

        private ExchangeRepository _repo = new();
        private ProductRepository _pro_repo = new();
        public List<Exchange> GetAllExchange()
        {
            return _repo.GetAllExchange();
        }
        public Exchange GetExchange(int id)
        {
            return _repo.GetAllExchange().FirstOrDefault(e => e.ExchangeId == id);
        }
        public void MakeExchangeUI(string userName, int wantId, int ownId, int balance)
        {
            ProductService productService = new ProductService();
            UserService userService = new UserService();

            var user = userService.GetUserByName(userName);
            if (user == null) throw new Exception("Could not find user");

            var wantProduct = productService.GetProduct(wantId);
            if (wantProduct == null || wantProduct.Status != 1) throw new Exception("Could not find the product you want");

            var ownProduct = productService.GetProduct(ownId);
            if (ownProduct == null || ownProduct.Status != 1) throw new Exception("Could not find your Product");

            if (user.UserId == wantProduct.UserId) throw new Exception("You already own this product");
            if (user.UserId != ownProduct.UserId) throw new Exception("You don't own this product to exchange");

            ownProduct.Status = 2;
            productService.UpdateProduct(ownProduct);
            _repo.CreateExchange(user.UserId, wantProduct.ProductId, ownProduct.ProductId, balance);
        }

        public List<OwnExchangeView>? GetOwnExchange(int userId)
        {
            var userExchanges = _repo.GetUserExchanges(userId);

            var exchangeViews = userExchanges.Select(e => new OwnExchangeView()
            {
                ExchangeId = e.ExchangeId,
                WantedProductName = e.Product.ProductName,
                SellerName = e.Product.User.UserName,
                OwnProductName = e.ExchangeDetails.First().Product!.ProductName,
                Balance = (int)e.ExchangeDetails.First().Balance,
                CreateDate = e.CreateDate,
                Status = e.Status,
            }).ToList();

            return exchangeViews;
        }

        public void CancelExchange(int exchangeId)
        {
            _repo.RemoveExchange(exchangeId);
        }

        public List<ReceivedExchangeView>? GetSentExchange(int productId)
        {
            var exchanges = _repo.GetExchangesByProduct(productId);
            if (exchanges == null)
                return null;

            var result = exchanges.Select(e => new ReceivedExchangeView()
            {
                ExchangeId = e.ExchangeId,
                OfferProductName = e.ExchangeDetails.First().Product!.ProductName,
                BuyerName = e.User.UserName,
                OfferBalance = (int)e.ExchangeDetails.First().Balance! * (-1),
                CreateDate = e.CreateDate,
                OwnProductName = e.Product.ProductName,
                Status = e.Status,
            }).ToList();

            return result;
        }

        public void UserAcceptExchange(int exchangeId)
        {
            _repo.ExchangeAccept(exchangeId);
        }

        public void UserDeclineExchange(int exchangeId)
        {
            _repo.DeclineExchange(exchangeId);
        }
        public Product GetMyProductOfExchange(int exchangeId)
        {
            var ex = _repo.GetExchanges(exchangeId);
            return _pro_repo.GetProduct(ex.ProductId);
        }
        public Product GetTheirProductOfExchange(int exchangeId)
        {
            var ex = _repo.GetExchanges(exchangeId);
            var productId = ex.ExchangeDetails.FirstOrDefault().ProductId;
            if (productId.HasValue)
            {
                return _pro_repo.GetProduct(productId.Value);
            }
            return null;
        }
    }
}
