using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prombox.Web.Settings
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Minutes { get; set; }
    }
}
