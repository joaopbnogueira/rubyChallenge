using System;
using System.Threading.Tasks;
using Cabify.DataRepository;
using Microsoft.AspNetCore.Http;

namespace Cabify.Storefront.Services
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDataReader _dataReader;
        private readonly IDataWriter _dataWriter;
        public string Name => _httpContextAccessor.HttpContext.User.FindFirst("name")?.Value;
        public string ImageUrl => _httpContextAccessor.HttpContext.User.FindFirst("picture")?.Value;
        public string Email => _httpContextAccessor.HttpContext.User.FindFirst("email")?.Value;

        public UserContext(IHttpContextAccessor httpContextAccessor, IDataReader dataReader, IDataWriter dataWriter)
        {
            _httpContextAccessor = httpContextAccessor;
            _dataReader = dataReader;
            _dataWriter = dataWriter;
        }

        public async Task<Guid> GetUserId()
        {
            var userId =  await _dataReader.GetUserId(Email);
            if (userId == Guid.Empty)
            {
                userId = await _dataWriter.AddUser(Email);
            }
            return userId;
        }
    }
}
