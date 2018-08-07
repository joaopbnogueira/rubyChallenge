using System.Threading.Tasks;
using Cabify.DataRepository;
using Cabify.Storefront.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Cabify.Storefront.Mappers;

namespace Cabify.Storefront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {        
        private readonly IDataReader _dataReader;
        private readonly ProductsMapper _mapper;

        public ProductsController(IDataReader dataReader, ProductsMapper mapper)
        {
            _dataReader = dataReader;
            _mapper = mapper;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<ProductsViewModel>> Get()
        {
            var products = await _dataReader.GetAllProducts();
            return _mapper.Map(products);
        }
    }
}
