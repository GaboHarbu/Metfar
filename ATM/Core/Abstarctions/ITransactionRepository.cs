namespace ATM.Core.Abstarctions
{
    using Core.Domain;

    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        Task SaveChangesAsync();
        IEnumerable<Transaction> GetTransactions(int cardId);
    }
}
