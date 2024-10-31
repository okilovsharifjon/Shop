using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Exceptions
{
    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException(string message) : base(message)
        { }
    }
}
