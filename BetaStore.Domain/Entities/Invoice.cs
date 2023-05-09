using BetaStore.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace BetaStore.Domain.Entities
{
    public class Invoice : EntityBase
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Precision(18, 2)]
        public decimal InvoiceAmount { get; set; }
        [Precision(18, 2)]
        public decimal DiscountAmount { get; set; }
    }
}
