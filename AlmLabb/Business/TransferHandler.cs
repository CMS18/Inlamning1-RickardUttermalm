using AlmLabb.Business.Interfaces;
using AlmLabb.Exceptions;
using AlmLabb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmLabb.Business
{
    public class TransferHandler : ITransferHandler
    {
        private IMockDb _context;
        public TransferHandler(IMockDb context)
        {
            _context = context;
        }

        public TransactionResult Transfer(int fromId, int toId, decimal amount)
        {
            try
            {
                var fromAccount = _context.Accounts.First(a => a.AccountID == fromId);
                var toAccount = _context.Accounts.First(a => a.AccountID == toId);

                return Transfer(fromAccount, toAccount, amount);
            }
            catch (InvalidOperationException ex)
            {
                return new TransactionResult(false, "Could not find the account! " + ex.Message);
            }
        }

        public TransactionResult Transfer(Account from, Account to, decimal amount)
        {
            try
            {
                from.Debit(amount);
            }
            catch (InvalidTransactionException)
            {
                return new TransactionResult(false, "Not enough money on sending account!");
            }

            to.Credit(amount);
            return new TransactionResult(true, $"Transfer of {amount} from account #{from.AccountID}" +
                $" to #{to.AccountID} was successful! " +
                $"The new Balance is {from.Balance} and {to.Balance}");
        }
    }

}
