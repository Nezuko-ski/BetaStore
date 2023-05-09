using BetaStore.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BetaStore.Core.DTOs
{
    public class InvoiceRequestDTO
    {
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
