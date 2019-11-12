using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Business.Interfaces
{
    public interface IMockDb
    {
        List<Customer> Customers {get; set;}
        List<Account> Accounts {get; set;}
    }
}
