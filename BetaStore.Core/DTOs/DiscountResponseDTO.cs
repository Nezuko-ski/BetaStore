using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaStore.Core.DTOs
{
    public class DiscountResponseDTO
    {
        public string Name { get; set; }
        [Precision (18, 2)]
        public decimal Percentage { get; set; }
    }
}
