using AlmLabb.Business.Interfaces;
using AlmLabb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Business
{
    public class TransactionHandler
    {
        private IMockDb _context;
        public TransactionHandler(IMockDb context)
        {
            _context = context;
        }

        public void Deposit(TransactionViewModel model)
        {
            foreach (var item in _context.Accounts)
            {
                if (item.AccountID == model.AccountID)
                {
                    item.Balance += model.Amount;
                }
            }
        }

        public void Withdraw(TransactionViewModel model)
        {
            foreach (var item in _context.Accounts)
            {
                if (item.AccountID == model.AccountID)
                {
                    item.Balance -= model.Amount;
                }
            }
        }
    }
}
