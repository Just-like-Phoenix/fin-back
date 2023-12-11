using Microsoft.EntityFrameworkCore;

namespace fin_back.Models.Indicators
{
    public class FinancialIndicators
    {
        public double Leverage { get; set; }
        public double CoverageRatio { get; set; }
    }
}
