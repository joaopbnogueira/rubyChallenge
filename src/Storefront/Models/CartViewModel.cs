using System;
using Cabify.DataRepository.Model;

namespace Cabify.Storefront.Models
{
    public class CartViewModel
    {
        public Guid CartId { get; set; }
        public CartItemViewModel[] Items { get; set; }
        public string Total { get; set; }
        
        public CartViewModel(Guid cartId, Product[] product)
        {
            
        }
    }
}
