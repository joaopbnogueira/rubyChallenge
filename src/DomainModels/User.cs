﻿using System;

namespace Cabify.DomainModels
{
    public class User
    {                
        public Guid Id { get; set; }
        
        public string Email { get; set; }
        
        public Cart Cart { get; set; }        
    }
}