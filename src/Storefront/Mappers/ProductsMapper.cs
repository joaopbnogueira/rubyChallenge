using System.Linq;
using Cabify.DomainModels;
using Cabify.Storefront.Models.Responses;

namespace Cabify.Storefront.Mappers
{
    public class ProductsMapper : MapperBase
    {
        public ProductsViewModel Map(Product[] products)
        {
            var itemViewModels = products.Select(p => new ProductItemViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = ToPriceString(p.Price)
            }).ToList();

            return new ProductsViewModel
            {
                Items = itemViewModels,
            };
        }
    }
}
