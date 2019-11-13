namespace AlmLabb.Business
{
    public interface ITransferHandler
    {
        TransactionResult Transfer(Account from, Account to, decimal amount);
        TransactionResult Transfer(int fromId, int toId, decimal amount);
    }
}