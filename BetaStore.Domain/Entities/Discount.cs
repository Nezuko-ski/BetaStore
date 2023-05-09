using BetaStore.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace BetaStore.Domain.Entities
{
    public class Discount : EntityBase
    {
        public string Name { get; set; }
        [Precision(18, 2)]
        public decimal Percentage { get; set; }

    }
}
