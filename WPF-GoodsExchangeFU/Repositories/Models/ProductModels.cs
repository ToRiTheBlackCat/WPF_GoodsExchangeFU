using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class ProductModels
    {
        public class ProductView
        {
            public required int ProductId { get; set; }

            public required string ProductName { get; set; } = null!;

            public required string ProductImage { get; set; } = null!;

            public required string? ProductDescription { get; set; }

            public required int ProductPrice { get; set; }

            public required string TypeName { get; set; }

            public required string UserName { get; set; }
        }
    }
}
