using System.Reflection.Metadata;

namespace fin_back.Models.Organization
{
    public class OrganizationIndicatorsCreate
    {
        public int? Year { get; set; }
        public int RegNum { get; set; }

        public string? BalanceFile { get; set; }
        public string? ProfitNLossFile { get; set; }
        public string? CashFlowFile { get; set; }
    }
}
