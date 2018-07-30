using System;

namespace Cabify.DataRepository.Model
{
    public class CartProduct
    {
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
