﻿using Azure.Core;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseRequestsController : ControllerBase
    {
        BookStoreManager bookStoreManager = new BookStoreManager();
        [HttpPost]
        public ActionResult<PurchaseResponse> HandlePurchase(PurchaseRequest purchaseRequest)
        {
            decimal totalPrice = purchaseRequest.Books.Sum(book => book.Price);
            bookStoreManager.HandlePurchase(purchaseRequest);

            decimal discount = 0;
            if (purchaseRequest.BaseCustomer is Premium)
            {
                //   discount = bookStoreManager.CalculatePremiumDiscount(purchaseRequest.BaseCustomer as Premium, totalPrice);
                discount = bookStoreManager.CalculateDiscount(purchaseRequest.BaseCustomer as Premium, totalPrice);
            }
            else if (purchaseRequest.BaseCustomer is Regular)
            {
                //  discount = bookStoreManager.CalculateRegularDiscount(purchaseRequest.BaseCustomer as Regular, totalPrice);
                discount = bookStoreManager.CalculateDiscount(purchaseRequest.BaseCustomer as Regular, totalPrice);


            }
            decimal discountedAmount = purchaseRequest.TotalAmount * discount;
            decimal finalPrice = purchaseRequest.TotalAmount - discountedAmount;
            // Burada indirim hesaplaması yapabilirsiniz.

            var response = new PurchaseResponse
            {
                OriginalPrice = totalPrice,
                DiscountedAmount = discountedAmount,
                FinalPrice = finalPrice
                // İndirim miktarını ve son fiyatı burada ayarlayın
            };

            return Ok(response);
        }

    }
}
