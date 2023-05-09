namespace BetaStore.Core.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        Task Commit();
        Task CreateTransaction();
        void Dispose();
        Task Rollback();
        Task Save();
    }
}
