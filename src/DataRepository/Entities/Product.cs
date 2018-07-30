using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cabify.DataRepository.Entities
{
    public class Product
    {        
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }        

        public ICollection<CartProduct> CartProducts { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
