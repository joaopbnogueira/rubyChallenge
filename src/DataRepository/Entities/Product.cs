using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cabify.DataRepository.Entities
{
    public class Product
    {        
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [NotMapped]
        public decimal? PromoPrice { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
