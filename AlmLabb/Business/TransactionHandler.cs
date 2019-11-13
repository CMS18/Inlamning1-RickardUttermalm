using AlmLabb.Business.Interfaces;
using AlmLabb.Exceptions;
using AlmLabb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Business
{
    public class TransactionHandler : ITransactionHandler
    {
        private IMockDb _context;
        public TransactionHandler(IMockDb context)
        {
            _context = context;
        }
        public TransactionResult Handle(TransactionViewModel transaction)
        {
            if (transaction.Amount <= 0)
            {
                return new TransactionResult(false, "Amount must be positive.");
            }
            if (transaction.TransactionType == "Deposit")
            {
                var result = this.Deposit(transaction);
                return result;
            }
            else if (transaction.TransactionType == "Withdraw")
            {
                var result = this.Withdraw(transaction);
                return result;
            }
            return new TransactionResult(false, "Something went wrong :(");
        }

        private TransactionResult Deposit(TransactionViewModel model)
        {
            foreach (var item in _context.Accounts)
            {
                if (item.AccountID == model.AccountID)
                {
                    item.Balance += model.Amount;
                    return new TransactionResult(true, model.Amount + " was deposited into Account " +
                                                item.AccountID + ", Balance is now " + item.Balance);
                }
            }

            return new TransactionResult(false, "Accountnumber is not valid.");
        }

        private TransactionResult Withdraw(TransactionViewModel model)
        {
            foreach (var item in _context.Accounts)
            {
                if (item.AccountID == model.AccountID)
                {
                    if (item.Balance < model.Amount)
                    {
                        return new TransactionResult(false, "Balance of account " + item.AccountID + " is to low.");
                    }
                    item.Balance -= model.Amount;

                    return new TransactionResult(true, model.Amount + " was withdrawed from Account " +
                                                       item.AccountID + ", Balance is now " + item.Balance);
                }
            }
            return new TransactionResult(false, "Something went wrong :(");
        }

    }

}
