using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storefront.Models
{
    public class CartViewModel
    {
        public CartItemViewModel[] Items { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
    }
}
