using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cabify.DataRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cabify.DataRepository
{
    internal class DataReader : IDataReader
    {
        private readonly StorefrontContext _context;
        private readonly IMapper _mapper;

        public DataReader(StorefrontContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public async Task<Guid> GetUserId(string email)
        {
            return await _context.Users.Where(u => u.Email == email).Select(u => u.Id).FirstOrDefaultAsync();
        }
        
        public async Task<Guid> GetUserCartId(Guid userId)
        {
            return await _context.Carts.AsNoTracking().Where(c => c.UserId == userId).Select(c => c.Id).FirstOrDefaultAsync();
        }

        public async Task<DomainModels.Product[]> GetCartProducts(Guid userId, Guid cartId)
        {
            var cartProducts = await _context.Carts.Where(c => c.Id == cartId && c.UserId == userId).Select(c => c.CartProducts.Select(cp => cp.Product)).FirstOrDefaultAsync();
            return _mapper.Map<Product[], DomainModels.Product[]>(cartProducts.ToArray());
        }

        public async Task<DomainModels.Product[]> GetAllProducts()
        {
            var products = await _context.Products.ToArrayAsync();
            return _mapper.Map<Product[], DomainModels.Product[]>(products);
        }
    }
}
