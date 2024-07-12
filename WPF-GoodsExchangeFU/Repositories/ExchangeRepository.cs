using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repositories.Models.ExchangeModel;

namespace Repositories
{
    public class ExchangeRepository
    {
        GoodsExchangeFudbContext _context;
        public List<Exchange> GetAllExchange()
        {
            _context = new();
            return _context.Exchanges.Include("ExchangeDetails")
                                     .Include("Product").ToList();
        }
        public List<Exchange> GetExchanges()
        {
            _context = new GoodsExchangeFudbContext();
            return _context.Exchanges.Include(e => e.ExchangeDetails).AsNoTracking().ToList();
        }

        public void CreateExchange(int userId, int wantId, int ownId, int balance)
        {
            _context = new GoodsExchangeFudbContext();
            var addedExchange = _context.Exchanges.Add(new Exchange()
            {
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                ProductId = wantId,
                Status = 2,
                UserId = userId,
            });
            _context.SaveChanges();

            var exId = addedExchange.Entity.ExchangeId;
            _context.ExchangeDetails.Add(new ExchangeDetail()
            {
                Balance = balance,
                ExchangeId = exId,
                ProductId = ownId,
            });
            _context.SaveChanges();
        }

        public List<Exchange> GetUserExchanges(int userId)
        {
            _context = new GoodsExchangeFudbContext();
            var userExchanges = _context.Exchanges
                .Include(e => e.Product).ThenInclude(p => p.User)
                .Include(e => e.ExchangeDetails)
                .ThenInclude(e => e.Product)
                .Where(e => e.UserId == userId);

            return userExchanges.ToList();
        }

        public void RemoveExchange(int exchangeId)
        {
            _context = new GoodsExchangeFudbContext();
            var exchange = _context.Exchanges.Include(ex => ex.ExchangeDetails).ThenInclude(ed => ed.Product).FirstOrDefault(ex => ex.ExchangeId == exchangeId);
            if (exchange == null) 
            {
                throw new Exception("Exchange not found");
            }
            var exchangeDetail = exchange.ExchangeDetails.First();

            Product product = exchangeDetail.Product!;
            if (product.Status == 2)
                product.Status = 1;

            
            _context.ExchangeDetails.Remove(exchangeDetail);
            _context.Exchanges.Remove(exchange);
            _context.SaveChanges();
        }

        public List<Exchange> GetExchangesByProduct(int productId)
        {
            _context = new();
            var exchange = _context.Exchanges.Where(e => e.ProductId == productId && e.Status == 2)
                .Include(e => e.ExchangeDetails).ThenInclude(ed => ed.Product)
                .Include(e => e.User)
                .Include(e => e.Product)
                .AsNoTracking().ToList();

            return exchange;
        }

        public void ExchangeAccept(int exchangeId)
        {
            _context = new();
            var exchange = _context.Exchanges
                .Include(e => e.ExchangeDetails).ThenInclude(ed => ed.Product)
                .Include(e => e.User)
                .Include(e => e.Product)
                .FirstOrDefault(e => e.ExchangeId == exchangeId && e.Status == 2);
            if (exchange == null) 
            { 
                throw new Exception("Exchange not found");
            }
            var exchangeDetails = exchange.ExchangeDetails;
            var offerProduct = exchange.ExchangeDetails.First().Product;
            var ownProduct = exchange.Product;

            if (ownProduct.Status != 1)
            {
                throw new Exception("Your product is not available to accept exchange");
            }

            if (offerProduct.Status != 2)
            {
                throw new Exception("Offer product is not available to accept exchange");
            }

            exchange.Status = 1;

            offerProduct.Status = 0;
            ownProduct.Status = 0;
            _context.SaveChanges();

            //Cancel all other incoming request
            _context = new();
            var cancelExchanges = _context.Exchanges.Where(e => e.ProductId == ownProduct.ProductId && e.ExchangeId != exchange.ExchangeId)
                .Include(e => e.ExchangeDetails).ThenInclude(ed => ed.Product);

            foreach (var canceled in cancelExchanges)
            {
                canceled.Status = 0;
                if (canceled.ExchangeDetails.First().Product != null && canceled.ExchangeDetails.First().Product.Status == 2)
                    canceled.ExchangeDetails.First().Product.Status = 1;
            }
            _context.SaveChanges();
        }

        public void DeclineExchange(int exchangeId)
        {
            _context = new();
            var exchange = _context.Exchanges
                .Include(e => e.ExchangeDetails).ThenInclude(ed => ed.Product)
                .FirstOrDefault(e => e.ExchangeId == exchangeId && e.Status == 2);
            if (exchange == null)
            {
                throw new Exception("Exchange not found");
            }

            var offerProduct = exchange.ExchangeDetails.FirstOrDefault().Product;

            exchange.Status = 0;
            if (offerProduct != null && offerProduct!.Status == 2)
                offerProduct.Status = 1;
            _context.SaveChanges();
        }

    }
}
