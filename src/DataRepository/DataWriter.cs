using System;
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
            var cartProduct = await _context.CartProducts.FirstOrDefaultAsync(cp => cp.UserId == userId && cp.ProductId == id);
            if (cartProduct == null)
            {
                cartProduct = new CartProduct {UserId = userId, ProductId = id};
                _context.Add(cartProduct);
            }

            cartProduct.Quantity += quantity;
            await _context.SaveChangesAsync();
        }

        public async Task EmptyCart(Guid userId)
        {
            var cartProduct = new CartProduct {UserId = userId};
            _context.Entry(cartProduct).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}



