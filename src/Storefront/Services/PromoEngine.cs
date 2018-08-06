using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cabify.DomainModels;

namespace Cabify.Storefront.Services
{
    public class PromoEngine: IPromoEngine
    {
        private readonly IMapper _mapper;

        // This business logic could be imported from some somewhere else (e.g. rules by configuration)
        static readonly Dictionary<string, Action<IEnumerable<Product>>> PromoStore = new Dictionary<string, Action<IEnumerable<Product>>>(StringComparer.OrdinalIgnoreCase)
        {
            {"VOUCHER", ApplyVoucherPromo},
            {"TSHIRT", ApplyTshirtPromo}
        };


        public PromoEngine(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IReadOnlyCollection<Product> ApplyPromos(IReadOnlyCollection<Product> products)
        {
            var expandedProducts = products.SelectMany(p => Enumerable.Range(0, p.Quantity).Select(i => {
                    var clone = _mapper.Map<Product, Product>(p);
                    clone.Quantity = 1;
                    return clone;                    
                })).ToArray();

            foreach (var code in PromoStore.Keys)
            {
                PromoStore[code].Invoke(expandedProducts.Where(p => p.Id == code));
            }

            return expandedProducts;
        }


        private static void ApplyVoucherPromo(IEnumerable<Product> products)
        {
            var i = 0;
            foreach (var product in products)
            {
                if (i % 2 == 0)
                {
                    product.PromoPrice = 0.00m;
                }
            }            
        }

        private static void ApplyTshirtPromo(IEnumerable<Product> products)
        {
            var i = 0;
            foreach (var product in products)
            {
                if (i >= 3)
                {
                    product.PromoPrice = 19.00m;
                }
            }
        }
    }
}
