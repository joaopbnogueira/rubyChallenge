using System.Collections.Generic;

namespace Cabify.Storefront.Models.Responses
{
    public class ProductsViewModel
    {
        public ICollection<ProductItemViewModel> Items { get; set; }        
    }
}