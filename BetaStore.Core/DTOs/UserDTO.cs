using BetaStore.Domain.Entities;

namespace BetaStore.Core.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CustomerSince { get; set; }
        public List<Invoice> Invoices { get; set; }
        public DateTime DateCreated { get; set; }


    }
}
