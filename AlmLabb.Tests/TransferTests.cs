using AlmLabb.Business;
using AlmLabb.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlmLabb.Tests
{
    public class TransferTests
    {


        [Theory]
        [InlineData(100, 8429, 100)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 5151, 0)]
        [InlineData(100, 0, 100)]
        [InlineData(99999999, 0, 99999999)]
        [InlineData(100, 100, 100)]
        public void VerifyCorrectBalanceAfterTransfer(decimal fromBalance, decimal toBalance, decimal amount)
        {
            var db = new MockDb();
            var transactionHandler = new TransferHandler(db);

            var fromAccount = new Account() { Balance = fromBalance };
            var toAccount = new Account() { Balance = toBalance };

            transactionHandler.Transfer(fromAccount, toAccount, amount);

            Assert.True(fromAccount.Balance == fromBalance - amount);
            Assert.True(toAccount.Balance == toBalance + amount);
        }

        [Theory]
        [InlineData(100, 8429, 101)]
        [InlineData(1, 0, 2)]
        [InlineData(0, 5151, 5)]
        [InlineData(100, 0, 9999999999)]
        [InlineData(99999999, 0, 999999999)]
        [InlineData(100, 1000, 500)]
        public void ShouldntBeAbleToWithdrawMoreThanBalanceYo(decimal fromBalance, decimal toBalance, decimal amount)
        {
            var db = new MockDb();
            var transactionHandler = new TransferHandler(db);

            var fromAccount = new Account() { Balance = fromBalance };
            var toAccount = new Account() { Balance = toBalance };

            var result = transactionHandler.Transfer(fromAccount, toAccount, amount);

            //Assert.Throws<InvalidTransactionException>(() => transactionHandler.Transfer(fromAccount, toAccount, amount));
            Assert.False(result.IsSuccessful);
            Assert.True(fromAccount.Balance == fromBalance);
        }
    }
}
