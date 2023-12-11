using fin_back.Models.Indicators;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace fin_back.Data.Entities
{
    [PrimaryKey(nameof(Year), nameof(RegNum))]
    public class OrganizationIndicators
    {
        [Required]
        public int? Year { get; set; }
        
        [Required]
        [ForeignKey(nameof(RegNum))]
        public int RegNum { get; set; }
        public Organization? Organization { get; set; }

        public byte[]? BalanceFile { get; set; }
        public byte[]? ProfitNLossFile { get; set; }
        public byte[]? CashFlowFile { get; set; }

        public LiquidityIndicators? LiquidityIndicators { get; set; } = null!;
        public FinancialIndicators? FinancialIndicators { get; set; } = null!;
        public ProfitabilityIndicators? ProfitabilityIndicators { get; set; } = null!;
    }
}

