using System;
using System.Threading.Tasks;

namespace Cabify.DataRepository
{
    public interface IDataWriter
    {
        Task<Guid> AddUser(string email);        
        Task AddProduct(Guid userId, string id, int quantity);
        Task EmptyCart(Guid userId);
    }
}