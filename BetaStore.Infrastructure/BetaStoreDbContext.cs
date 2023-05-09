using BetaStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetaStore.Infrastructure
{
    public class BetaStoreDbContext : IdentityDbContext<Customer>
    {
        public BetaStoreDbContext(DbContextOptions<BetaStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
    }
}
