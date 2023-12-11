using Microsoft.EntityFrameworkCore;

namespace fin_back.Models.Indicators
{
    public class ProfitabilityIndicators
    {
        public double ReturnOnAssets { get; set; }
        public double ReturnOnEquity { get; set; }
        public double ReturnOnInvestment { get; set; }
    }
}
