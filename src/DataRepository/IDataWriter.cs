using System;
using System.Threading.Tasks;

namespace Cabify.DataRepository
{
    public interface IDataWriter
    {
        Task<Guid> AddUser(string email);
        Task<Guid> AddCart(Guid userId);
    }
}