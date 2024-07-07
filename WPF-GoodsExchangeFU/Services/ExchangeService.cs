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
        private ExchangeRepository _repo = new();
        public List<Exchange> GetAllExchange()
        {
            return _repo.GetAllExchange();
        }
    }
}
