using AutoMapper;

namespace Cabify.DomainModels
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, Product>();            
        }
    }
}
