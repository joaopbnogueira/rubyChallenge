using System;
using System.Globalization;
using System.Linq;
using Cabify.DomainModels;
using Cabify.Storefront.Models;
using Cabify.Storefront.Models.Responses;
using Cabify.Storefront.Services;

namespace Cabify.Storefront.Mappers
{
    public class CartMapper
    {
        private static readonly CultureInfo Portugal = new CultureInfo("pt-PT");

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
                // Prices assume PT location/format/currency for simplicity
                Price = p.Price.ToString("C", Portugal),
                PromoPrice = p.PromoPrice?.ToString("C", Portugal)
            }).ToList();
            
            return new CartViewModel
            {
                CartId = cartId,
                Items = itemViewModels,
                Total = itemsWithPromos.Sum(p => p.PromoPrice ?? p.Price).ToString("C", Portugal)
            };
        }
    }
}
