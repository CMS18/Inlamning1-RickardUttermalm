using AlmLabb.Business;
using AlmLabb.Models.ViewModels;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlmLabb.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(-100, "Deposit")]
        [InlineData(-100, "Withdraw")]
        [InlineData(0, "Withdraw")]
        public async Task TransactionHandlerTests(decimal amount, string type)
        {
            var Repo = new MockDb();
            var _handler = new TransactionHandler(Repo);

            var transaction = new TransactionViewModel();
            transaction.AccountID = 1;
            transaction.Amount = amount;
            transaction.TransactionType = type;

            var result = _handler.Handle(transaction);

            var expected = 100;

            Assert.False(result.IsSuccessful);
            Assert.Equal(expected, Repo.Accounts[0].Balance);
        }

    }
}
