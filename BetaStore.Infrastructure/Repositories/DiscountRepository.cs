using BetaStore.Core.Interfaces;
using BetaStore.Domain.Entities;

namespace BetaStore.Infrastructure.Repositories
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(BetaStoreDbContext context) : base(context)
        {
        }
    }
}
