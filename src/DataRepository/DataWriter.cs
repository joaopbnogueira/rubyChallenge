using System;
using System.Linq;
using System.Threading.Tasks;
using Cabify.DataRepository.Model;
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
        

        public async Task<Guid> AddCart(Guid userId)
        {
            var cart = new Cart
            {
                UserId = userId
            };

            _context.Carts.Add(cart);

            await _context.SaveChangesAsync();

            return cart.Id;
        }    
    }
}
