using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cabify.DataRepository.Model
{
    public class Cart
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }     
    }
}
