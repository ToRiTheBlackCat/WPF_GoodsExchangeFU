using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class ExchangeModel
    {
        public class OwnExchangeView()
        {
            public required int ExchangeId { get; set; }

            public required string WantedProductName { get; set; }

            public required string SellerName { get; set; }

            public required string OwnProductName { get; set; }

            public required int Balance { get; set; }

            public required DateOnly CreateDate { get; set; }

            public required int Status { get; set; }
        }

        public class ReceivedExchangeView()
        {
            public required int ExchangeId { get; set; }

            public required string OfferProductName { get; set; }

            public required string BuyerName { get; set; }

            public required string OwnProductName { get; set; }

            public required int OfferBalance { get; set; }

            public required DateOnly CreateDate { get; set; }

            public required int Status { get; set; }
        }
    }
}
