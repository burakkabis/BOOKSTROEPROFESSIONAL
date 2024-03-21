using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumsController : ControllerBase
    {
        IPremiumService _premiumService;

        public PremiumsController(IPremiumService premiumService)
        {
            _premiumService = premiumService;
        }

        [HttpPost("add")]
        public IActionResult Add(Premium premium)
        {
            _premiumService.Add(premium);
            return Ok("eklendi");

        }
    }

}