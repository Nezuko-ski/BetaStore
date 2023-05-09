using BetaStore.Core.Interfaces;
using BetaStore.Domain.Entities;

namespace BetaStore.Infrastructure.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(BetaStoreDbContext context) : base(context)
        {
        }
    }
}
