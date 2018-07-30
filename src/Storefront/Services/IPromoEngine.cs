using System.Collections.Generic;
using Cabify.DomainModels;

namespace Cabify.Storefront.Services
{
    public interface IPromoEngine
    {
        IReadOnlyCollection<Product> ApplyPromos(IReadOnlyCollection<Product> products);
    }
}
