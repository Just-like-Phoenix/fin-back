using Microsoft.EntityFrameworkCore;

namespace fin_back.Models.Indicators
{
    public class LiquidityIndicators
    {
        public double CurrentLiquidity { get; set; }
        public double FastLiquidity { get; set; }
        public double FreeCashFlow { get; set; }
        public double AccountsRecTurnover { get; set; }
        public double ReservesTurnover { get; set; }
        public double AccountsPayTurnover { get; set; }
        public double FinancialCycle { get; set; }
    }
}
