using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Exceptions
{
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException() : base("Tried to withdraw more than balance")
        {

        }

    }
}
