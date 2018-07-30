using System;
using System.Linq;
using System.Threading.Tasks;
using Cabify.DataRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace Cabify.DataRepository
{
    internal class DataReader : IDataReader
    {
        private readonly StorefrontContext _context;

        public DataReader(StorefrontContext context)
        {
            _context = context;
        }
       
        public async Task<Guid> GetUserId(string email)
        {
            return await _context.Users.Where(u => u.Email == email).Select(u => u.Id).FirstOrDefaultAsync();
        }
        
        public async Task<Guid> GetUserCartId(Guid userId)
        {
            return await _context.Carts.AsNoTracking().Where(c => c.UserId == userId).Select(c => c.Id).FirstOrDefaultAsync();
        }

        public async Task<Product[]> GetCartProducts(Guid userId, Guid cartId)
        {
            var cartProducts = await _context.Carts.Where(c => c.Id == cartId && c.UserId == userId).Select(c => c.CartProducts.Select(cp => cp.Product)).FirstOrDefaultAsync();
            return cartProducts.ToArray();
        }
    }
}
