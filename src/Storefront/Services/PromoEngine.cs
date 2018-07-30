using System;
using System.Collections.Generic;
using System.Linq;
using Cabify.DomainModels;

namespace Cabify.Storefront.Services
{
    public class PromoEngine: IPromoEngine
    {
        // This business logic could be imported from some somewhere else (e.g. rules by configuration)
        static readonly Dictionary<string, Action<IEnumerable<Product>>> PromoStore = new Dictionary<string, Action<IEnumerable<Product>>>(StringComparer.OrdinalIgnoreCase)
        {
            {"VOUCHER", ApplyVoucherPromo},
            {"TSHIRT", ApplyTshirtPromo}
        };

        public IReadOnlyCollection<Product> ApplyPromos(IReadOnlyCollection<Product> products)
        {
            foreach (var code in PromoStore.Keys)
            {
                PromoStore[code].Invoke(products.Where(p => p.Id == code));
            }
            return products;
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
