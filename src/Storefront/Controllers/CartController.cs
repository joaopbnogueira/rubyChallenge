using System;
using System.Threading.Tasks;
using Cabify.DataRepository;
using Cabify.Storefront.Mappers;
using Cabify.Storefront.Models.Requests;
using Cabify.Storefront.Models.Responses;
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
        private readonly CartMapper _mapper;

        public CartController(IUserContext userContext, IDataReader dataReader, IDataWriter dataWriter, CartMapper mapper)
        {
            _userContext = userContext;
            _dataReader = dataReader;
            _dataWriter = dataWriter;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<CartViewModel>> Get()
        {
            var userId = await _userContext.GetUserId();       

            var products = await _dataReader.GetCartProducts(userId);

            return _mapper.Map(products);
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> PutProduct([FromBody] PutProductInCart request)
        {
            var userId = await _userContext.GetUserId();
            await _dataWriter.AddProduct(userId, request.ProductId, request.Quantity);
            return Ok();
        }

        [Route("")]
        [HttpDelete]
        public async Task<IActionResult> EmptyCart()
        {
            var userId = await _userContext.GetUserId();
            await _dataWriter.EmptyCart(userId);
            return Ok();
        }
    }
}
