using System;
using System.Collections.Generic;

namespace Cabify.Storefront.Models.Responses
{
    public class CartViewModel
    {
        public Guid CartId { get; set; }
        public IReadOnlyCollection<CartItemViewModel> Items { get; set; }
        public string Total { get; set; }           
    }

}
