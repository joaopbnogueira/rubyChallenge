using AutoMapper;
using Cabify.DomainModels;

namespace Cabify.DataRepository
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Entities.Product, Product>(MemberList.Destination);

            CreateMap<Entities.Cart, Cart>(MemberList.Destination);
        }
    }
}
