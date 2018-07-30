using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cabify.DataRepository.Model
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
