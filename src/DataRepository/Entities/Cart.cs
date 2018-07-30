using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cabify.DataRepository.Entities
{
    public class Cart
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
