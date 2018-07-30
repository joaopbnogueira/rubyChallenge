using System;
using System.Threading.Tasks;
using Cabify.DataRepository.Model;

namespace Cabify.DataRepository
{
    public interface IDataWriter
    {
        Task<Guid> AddUser(string email);
        Task<Guid> AddCart(Guid userId);
    }
}