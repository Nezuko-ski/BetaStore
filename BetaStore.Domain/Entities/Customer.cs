using Microsoft.AspNetCore.Identity;

namespace BetaStore.Domain.Entities
{
    public class Customer : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime CustomerSince { get; set; }
        public List<Invoice> Invoices { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
