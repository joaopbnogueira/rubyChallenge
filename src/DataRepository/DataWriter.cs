using System;
using System.Linq;
using System.Threading.Tasks;
using Cabify.DataRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cabify.DataRepository
{
    internal class DataWriter : IDataWriter
    {
        private readonly StorefrontContext _context;

        public DataWriter(StorefrontContext context)
        {
            _context = context;
        }
        
        public async Task<Guid> AddUser(string email)
        {
            var user = new User
            {
                Email = email
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task AddProduct(Guid userId, string id, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                _context.Add(new CartProduct { UserId = userId, ProductId = id });
            }

            await _context.SaveChangesAsync();
        }

        public async Task EmptyCart(Guid userId)
        {
            var cartProducts = await _context.Users.Where(u => u.Id == userId).Select(c => c.CartProducts).FirstOrDefaultAsync();
            _context.CartProducts.RemoveRange(cartProducts);
            await _context.SaveChangesAsync();
        }
    }
}



