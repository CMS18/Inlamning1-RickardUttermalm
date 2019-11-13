using AlmLabb.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Business
{
    public class MockDb : IMockDb
    {
        public List<Customer> Customers { get; set; }
        public List<Account> Accounts { get; set; }
        public MockDb()
        {
            Accounts = new List<Account>
            {
                new Account(){Balance = 100m, CustomerID = 1, AccountID = 1},
                new Account(){Balance = 100m, CustomerID = 2, AccountID = 2},
                new Account(){Balance = 100m, CustomerID = 3, AccountID = 3}
            };

            Customers = new List<Customer>
            {
                new Customer(){FirstName = "Sven", LastName = "Svensson", CustomerID = 1, Account = Accounts[0]},
                new Customer(){FirstName = "Erik", LastName = "Eriksson", CustomerID = 2, Account = Accounts[1]},
                new Customer(){FirstName = "Lars", LastName = "Larsson", CustomerID = 3, Account = Accounts[2]}
            };

        }


        public void Transfer(Account from, Account to)
        {

        }

    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => this.FirstName + " " + this.LastName; }

        public int CustomerID { get; set; }

        public virtual Account Account { get; set; }
    }
    public class Account
    {
        public decimal Balance { get; set; }
        public int AccountID { get; set; }
        public int CustomerID { get; set; }

        public void Credit(decimal amount)
        {
            Balance += amount;
        }

        public void Debit(decimal amount)
        {
            if (Balance < amount)
            {
throw new e
            }
            Balance -= amount;

        }
    }
}
