using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PurchaseResponse
    {
        public decimal OriginalPrice { get; set; }
        public decimal DiscountedAmount { get; set; }
        public decimal FinalPrice { get; set; }

    }
}
