using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookStoreManager : IBookStoreService
    {
        public decimal CalculateDiscount(BaseCustomer baseCustomer, decimal totalAmount)
        {
            switch (baseCustomer)
            {
                case Regular:
                    return 0;
                case Premium:
                    return totalAmount > 100 ? 0.10m : 0;
                case Employee:
                    return 0.30m;
                default:
                    return 0;
            }


           
        }

        public PurchaseResponse HandlePurchase(PurchaseRequest request)
        {
            decimal discount = CalculateDiscount(request.BaseCustomer, request.TotalAmount);
            decimal discountedAmount = request.TotalAmount * discount;
            decimal finalPrice = request.TotalAmount - discountedAmount;

            return new PurchaseResponse
            {
                OriginalPrice = request.TotalAmount,
                DiscountedAmount = discountedAmount,
                FinalPrice = finalPrice
            };
        }
    }
}
