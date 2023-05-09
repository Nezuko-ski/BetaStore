using BetaStore.Domain.Entities;

namespace BetaStore.Core.Interfaces
{
    public interface IDiscountService
    {
        Task<bool> CreateDiscount(Discount discount);
        Task<List<Discount>> GetAllDiscountsAsync();
        Task<Discount> GetSpecificDiscount(string Id);
        Task<decimal> GetDiscountPercentageByName(string name);
        Task<Discount> GetDiscountByName(string name);
    }
}
