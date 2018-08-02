using System;
using System.Threading.Tasks;

namespace Cabify.DataRepository
{
    public interface IDataReader
    {
        Task<Guid> GetUserId(string email);
        Task<Guid> GetUserCartId(Guid userId);
        Task<DomainModels.Product[]> GetCartProducts(Guid userId, Guid cartId);
        Task<DomainModels.Product[]> GetAllProducts();
    }
}