using System;
using System.Threading.Tasks;

namespace Cabify.DataRepository
{
    public interface IDataReader
    {
        Task<Guid> GetUserId(string email);
        Task<DomainModels.Product[]> GetCartProducts(Guid userId);
        Task<DomainModels.Product[]> GetAllProducts();
    }
}