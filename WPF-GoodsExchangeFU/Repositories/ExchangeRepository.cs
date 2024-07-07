using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ExchangeRepository
    {
        GoodsExchangeFudbContext _context;
        public List<Exchange> GetAllExchange()
        {
            _context = new();
            return _context.Exchanges.ToList();
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
    }
}
