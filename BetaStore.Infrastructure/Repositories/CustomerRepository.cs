using BetaStore.Core.Interfaces;
using BetaStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetaStore.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly BetaStoreDbContext _context;
        public CustomerRepository(BetaStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
