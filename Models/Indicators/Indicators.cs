using fin_back.Data.Entities;

namespace fin_back.Models.Indicators
{
    public class Indicators
    {
        public LiquidityIndicators? LiquidityIndicators { get; set; } = null!;
        public FinancialIndicators? FinancialIndicators { get; set; } = null!;
        public ProfitabilityIndicators? ProfitabilityIndicators { get; set; } = null!;
    }
}
