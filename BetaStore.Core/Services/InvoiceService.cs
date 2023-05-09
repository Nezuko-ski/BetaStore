using BetaStore.Core.Interfaces;
using BetaStore.Domain.Entities;

namespace BetaStore.Core.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDiscountService _discountService;

        public InvoiceService(IUnitOfWork unitOfWork, IDiscountService discountService)
        {
            _unitOfWork = unitOfWork;
            _discountService = discountService;
        }
        public async Task<string> CalculateTotalInvoiceAmount(List<InvoiceItem> items, string customerId)
        {
            try
            {
                var customer = await _unitOfWork.CustomerRepository.GetAsync(v => v.Id == customerId);
                if (customer != null)
                {
                    decimal discountPercentage = await GetDiscountPercentageAsync(customer);
                    decimal discountAmount = discountPercentage * GetTotalAmountOnBill(items);
                    var totalDiscount = discountAmount;
                    var amountOnBillAfterDiscount = GetTotalAmountOnBill(items) - totalDiscount;
                    var invoice = new Invoice
                    {
                        InvoiceAmount = amountOnBillAfterDiscount,
                        DiscountAmount = totalDiscount,
                        DateCreated = DateTime.Now,
                    };
                    customer.Invoices = new List<Invoice> { invoice };
                    await _unitOfWork.CustomerRepository.Update(customer);
                    return amountOnBillAfterDiscount.ToString();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private static decimal GetTotalAmountOnBill(List<InvoiceItem> items) => items.Select(v => decimal
        .Parse(v.Amount)).ToList().Sum();

        private async Task<decimal> GetDiscountPercentageAsync(Customer customer)
        {
            var timeWithBetaStore = DateTime.Now - customer.CustomerSince;

            if (timeWithBetaStore.TotalDays < 30) // Less than a month
            {
                return await _discountService.GetDiscountPercentageByName("Less than a month");
            }
            else if (timeWithBetaStore.TotalDays < 180) // Between 1 and 6 months
            {
                return await _discountService.GetDiscountPercentageByName("1-6 months");
            }
            else if (timeWithBetaStore.TotalDays < 365) // Between 6 months and 1 year
            {
                return await _discountService.GetDiscountPercentageByName("6 months - 1 year");
            }
            else if (timeWithBetaStore.TotalDays < 730) // Between 1 and 2 years
            {
                return await _discountService.GetDiscountPercentageByName("1-2 years");
            }
            else // More than 2 years
            {
                return await _discountService.GetDiscountPercentageByName("More than 2 years");
            }
        }


        /*private static decimal GetDiscountPercentage(Customer customer)
        {
            var timeWithBetaStore = DateTime.Now - customer.CustomerSince;
            decimal discountPercentage;
            if (timeWithBetaStore.TotalDays < 30) // Less than a month
            {
                discountPercentage = 0m;
            }
            else if (timeWithBetaStore.TotalDays < 180) // Between 1 and 6 months
            {
                discountPercentage = 0.05m;
            }
            else if (timeWithBetaStore.TotalDays < 365) // Between 6 months and 1 year
            {
                discountPercentage = 0.1m;
            }
            else if (timeWithBetaStore.TotalDays < 730) // Between 1 and 2 years
            {
                discountPercentage = 0.15m;
            }
            else // More than 2 years
            {
                discountPercentage = 0.2m;
            }

            return discountPercentage;
        }*/


    }
}
