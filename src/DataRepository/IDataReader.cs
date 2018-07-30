using System;
using System.Threading.Tasks;
using Cabify.DataRepository.Model;

namespace Cabify.DataRepository
{
    public interface IDataReader
    {
        Task<Guid> GetUserId(string email);
        Task<Guid> GetUserCartId(Guid userId);        
        Task<Product[]> GetCartProducts(Guid userId, Guid cartId);        
    }
}