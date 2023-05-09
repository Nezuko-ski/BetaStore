using BetaStore.Domain.Entities;

namespace BetaStore.Core.Interfaces
{
    public interface IInvoiceService
    {
        Task<string> CalculateTotalInvoiceAmount(List<InvoiceItem> items, string customerId);
    }
}
