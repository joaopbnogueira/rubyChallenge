using System;
using System.Linq;
using Cabify.DomainModels;
using Cabify.Storefront.Models.Responses;
using Cabify.Storefront.Services;

namespace Cabify.Storefront.Mappers
{
    public class CartMapper : MapperBase
    {    
        private readonly IPromoEngine _promoEngine;

        public CartMapper(IPromoEngine promoEngine)
        {
            _promoEngine = promoEngine;
        }

        public CartViewModel Map(Guid cartId, Product[] products)
        {
            var itemsWithPromos = _promoEngine.ApplyPromos(products);

            var itemViewModels = products.Select(p => new CartItemViewModel
            {
                Code = p.Id,
                Name = p.Name,                
                Price = ToPriceString(p.Price),
                PromoPrice = ToPriceString(p.PromoPrice)
            }).ToList();
            
            return new CartViewModel
            {
                Id = cartId,
                Items = itemViewModels,
                Total = ToPriceString(itemsWithPromos.Sum(p => p.PromoPrice ?? p.Price))
            };
        }
    }
}
