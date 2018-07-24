using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storefront.Configuration
{
    public class OpenIdConfiguration
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string LogoutUri { get; set; }
    }
}
