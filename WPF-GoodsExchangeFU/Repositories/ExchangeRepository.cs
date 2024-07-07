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
    }
}
