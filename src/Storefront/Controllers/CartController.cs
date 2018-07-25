using Cabify.DataRepository;
using Microsoft.AspNetCore.Mvc;
using Storefront.Models;
using Storefront.Services;

namespace Storefront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IUserContext _userContext;
        private readonly ICartDataReader _cartDataReader;

        public CartController(IUserContext userContext, ICartDataReader cartDataReader)
        {
            _userContext = userContext;
            _cartDataReader = cartDataReader;
        }

        [Route("")]
        [HttpGet]
        public ActionResult<CartViewModel> Get()
        {
            return new CartViewModel();
        }

        [Route("item")]
        [HttpPut]
        public IActionResult PutItem([FromBody] int id)
        {
            return Ok();
        }

        [Route("voucher")]
        [HttpPut]
        public IActionResult PutVoucher([FromBody] string code)
        {
            return Ok();
        }
    }
}
