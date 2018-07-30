using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cabify.DataRepository.Model
{
    public class User
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public Guid Id { get; set; }
        
        public string Email { get; set; }
        
        public Cart Cart { get; set; }
    }
}
