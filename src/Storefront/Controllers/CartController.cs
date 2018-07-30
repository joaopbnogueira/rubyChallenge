using System;
using System.Threading.Tasks;
using Cabify.DataRepository;
using Cabify.Storefront.Models;
using Cabify.Storefront.Models.Requests;
using Cabify.Storefront.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cabify.Storefront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IUserContext _userContext;
        private readonly IDataReader _dataReader;
        private readonly IDataWriter _dataWriter;

        public CartController(IUserContext userContext, IDataReader dataReader, IDataWriter dataWriter)
        {
            _userContext = userContext;
            _dataReader = dataReader;
            _dataWriter = dataWriter;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<CartViewModel>> Get()
        {
            var userId = await _userContext.GetUserId();
            var cartId = await _dataReader.GetUserCartId(userId);
            if (cartId == Guid.Empty)
            {
                cartId = await _dataWriter.AddCart(userId);
            }
            var products = await _dataReader.GetCartProducts(userId, cartId);
            return new CartViewModel(cartId, products);            
        }

        [Route("{cartId}")]
        [HttpPut]
        public IActionResult PutProduct(Guid cartId, [FromBody] PutProductInCart request)
        {
            return Ok();
        }      
    }
}
