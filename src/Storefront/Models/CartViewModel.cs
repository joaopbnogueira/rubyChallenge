using System;
using System.Collections.Generic;
using Cabify.Storefront.Models.Responses;

namespace Cabify.Storefront.Models
{
    public class CartViewModel
    {
        public Guid CartId { get; set; }
        public IReadOnlyCollection<CartItemViewModel> Items { get; set; }
        public string Total { get; set; }           
    }
}
