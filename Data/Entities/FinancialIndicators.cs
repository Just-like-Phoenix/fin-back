using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fin_back.Data.Entities
{
    public class FinancialIndicators
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public double Leverage { get; set; }
        public double CoverageRatio { get; set; }
    }
}
