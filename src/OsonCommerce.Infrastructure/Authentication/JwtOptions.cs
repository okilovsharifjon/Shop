using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Infrastructure.Authentication
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public int ExpireHours { get; set; }
    }
}
