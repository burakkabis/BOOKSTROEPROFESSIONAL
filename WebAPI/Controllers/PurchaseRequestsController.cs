using Azure.Core;
using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class PurchaseRequestsController : ControllerBase
    //{
    //    BookStoreManager bookStoreManager = new BookStoreManager();
    //    [HttpPost]
    //    public ActionResult<PurchaseResponse> HandlePurchase(PurchaseRequest purchaseRequest)
    //    {
    //        decimal totalPrice = purchaseRequest.Books.Sum(book => book.Price);
    //        bookStoreManager.HandlePurchase(purchaseRequest);

    //        decimal discount = 0;
    //        if (purchaseRequest.BaseCustomer is Premium)
    //        {
    //            //   discount = bookStoreManager.CalculatePremiumDiscount(purchaseRequest.BaseCustomer as Premium, totalPrice);
    //            discount = bookStoreManager.CalculateDiscount(purchaseRequest.BaseCustomer as Premium, totalPrice);
    //        }
    //        else if (purchaseRequest.BaseCustomer is Regular)
    //        {
    //            //  discount = bookStoreManager.CalculateRegularDiscount(purchaseRequest.BaseCustomer as Regular, totalPrice);
    //            discount = bookStoreManager.CalculateDiscount(purchaseRequest.BaseCustomer as Regular, totalPrice);


    //        }
    //        decimal discountedAmount = purchaseRequest.TotalAmount * discount;
    //        decimal finalPrice = purchaseRequest.TotalAmount - discountedAmount;
    //        // Burada indirim hesaplaması yapabilirsiniz.

    //        var response = new PurchaseResponse
    //        {
    //            OriginalPrice = totalPrice,
    //            DiscountedAmount = discountedAmount,
    //            FinalPrice = finalPrice
    //            // İndirim miktarını ve son fiyatı burada ayarlayın
    //        };

    //        return Ok(response);
    //    }

    //}



    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseRequestsController : ControllerBase
    {
        IBookStoreService _bookStoreService;

        public PurchaseRequestsController(IBookStoreService bookStoreService)
        {
            _bookStoreService = bookStoreService;
        }

        [HttpPost]
        public ActionResult<PurchaseResponse> HandlePurchase(PurchaseRequest purchaseRequest)
        {
           // BaseCustomer customer = new Employee { Id = 1, Name = "Burak" };
           
            _bookStoreService.CalculateDiscount(purchaseRequest.BaseCustomer, purchaseRequest.TotalAmount);
           
            var response= _bookStoreService.HandlePurchase(purchaseRequest);

            return Ok(response.FinalPrice);
;
                 


        }
    }
}
