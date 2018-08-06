using System;
using System.ComponentModel.DataAnnotations;

namespace Cabify.DataRepository.Entities
{    
    public class CartProduct
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
