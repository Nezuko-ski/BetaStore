using BetaStore.Domain.Entities;

namespace BetaStore.Core.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetAllCustomersAsync();
    }
}
