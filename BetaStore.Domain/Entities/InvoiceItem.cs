using BetaStore.Domain.Base;

namespace BetaStore.Domain.Entities
{
    public class InvoiceItem : EntityBase
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Amount { get; set; }
    }
}
