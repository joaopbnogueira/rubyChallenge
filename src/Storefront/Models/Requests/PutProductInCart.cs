using System;

namespace Cabify.Storefront.Models.Requests
{

    public class PutProductInCart
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
