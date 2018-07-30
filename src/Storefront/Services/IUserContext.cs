using System;
using System.Threading.Tasks;

namespace Cabify.Storefront.Services
{
    public interface IUserContext
    {
        string Name { get; }
        string ImageUrl { get; }
        string Email { get; }
        Task<Guid> GetUserId();
    }
}
