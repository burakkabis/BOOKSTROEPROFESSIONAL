using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookStoreService
    {
        PurchaseResponse HandlePurchase(PurchaseRequest request);
        decimal CalculateDiscount(BaseCustomer baseCustomer, decimal totalAmount);
    }
}
