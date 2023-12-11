using ClosedXML.Excel;
using fin_back.Models.Indicators;

namespace fin_back.Extensions
{
    public class CalculateIndicators
    {
        public static Indicators CalculateAllIndicators(Stream balanceFile, Stream profitNLossFile, Stream cashFlowFile) 
        {
            var balanceWS = new XLWorkbook(balanceFile).Worksheet(1);
            var profitNLossWS = new XLWorkbook(profitNLossFile).Worksheet(1);
            var cashFlowWS = new XLWorkbook(cashFlowFile).Worksheet(1);

            var liquidityIndicators = new LiquidityIndicators 
            {
                CurrentLiquidity = ((GetCellNumber(balanceWS, "G53") - GetCellNumber(balanceWS, "G47")) / GetCellNumber(balanceWS, "G92")),
                FastLiquidity = ((GetCellNumber(balanceWS, "G53") - GetCellNumber(balanceWS, "G38") - GetCellNumber(balanceWS, "G47")) / GetCellNumber(balanceWS, "G92")),
                FreeCashFlow = (GetCellNumber(cashFlowWS, "G33") + GetCellNumber(cashFlowWS, "G37") - GetCellNumber(cashFlowWS, "G44") - GetCellNumber(cashFlowWS, "G63")),
                AccountsRecTurnover = (((GetCellNumber(balanceWS, "G49") - GetCellNumber(balanceWS, "G81") + GetCellNumber(balanceWS, "H49") - GetCellNumber(balanceWS, "H81")) / 2 ) / (GetCellNumber(profitNLossWS, "G20") * 365)),
                ReservesTurnover = (((GetCellNumber(balanceWS, "G38") + GetCellNumber(balanceWS, "H38")) / 2 ) / ( GetCellNumber(profitNLossWS, "G21") * 365 )),
                AccountsPayTurnover = (((GetCellNumber(balanceWS, "G78") - GetCellNumber(balanceWS, "G49") + GetCellNumber(balanceWS, "H78") - GetCellNumber(balanceWS, "H49"))/2) / (GetCellNumber(profitNLossWS, "G21") * 365)),
            };
            liquidityIndicators.FinancialCycle = liquidityIndicators.AccountsRecTurnover + liquidityIndicators.ReservesTurnover - liquidityIndicators.AccountsPayTurnover;

            var financialIndicators = new FinancialIndicators
            {
                Leverage = ((GetCellNumber(balanceWS, "G74") + GetCellNumber(balanceWS, "G92")) / GetCellNumber(balanceWS, "G66")),
                CoverageRatio = ((GetCellNumber(profitNLossWS, "G51") + GetCellNumber(profitNLossWS, "G45") + GetCellNumber(profitNLossWS, "G46") - GetCellNumber(profitNLossWS, "G32") - GetCellNumber(profitNLossWS, "G33") - GetCellNumber(profitNLossWS, "G41"))/ GetCellNumber(profitNLossWS, "G45"))
            };

            var profitabilityIndicators = new ProfitabilityIndicators 
            {
                ReturnOnAssets = (((GetCellNumber(profitNLossWS, "G57")) / ((GetCellNumber(balanceWS, "G54") + GetCellNumber(balanceWS, "H54")) / 2)) * 100),
                ReturnOnEquity = (((GetCellNumber(profitNLossWS, "G57")) / ((GetCellNumber(balanceWS, "G66") + GetCellNumber(balanceWS, "H66")) / 2)) * 100),
                ReturnOnInvestment = ((GetCellNumber(profitNLossWS, "G51") + GetCellNumber(profitNLossWS, "G45") + GetCellNumber(profitNLossWS, "G46") - 
                                       GetCellNumber(profitNLossWS, "G32") - GetCellNumber(profitNLossWS, "G33") - GetCellNumber(profitNLossWS, "G38")) / 
                                       ((GetCellNumber(balanceWS, "G66") + (GetCellNumber(balanceWS, "G68") + GetCellNumber(balanceWS, "G69") + GetCellNumber(balanceWS, "G76") + 
                                       GetCellNumber(balanceWS, "G77") + GetCellNumber(balanceWS, "G85")) + GetCellNumber(balanceWS, "H66") + (GetCellNumber(balanceWS, "H68") + 
                                       GetCellNumber(balanceWS, "H69") + GetCellNumber(balanceWS, "H76") + GetCellNumber(balanceWS, "H77") + GetCellNumber(balanceWS, "H85")))/ 2)*100)
            };

            var indicators = new Indicators 
            {
                LiquidityIndicators = liquidityIndicators,
                FinancialIndicators = financialIndicators,
                ProfitabilityIndicators = profitabilityIndicators,
            };

            return indicators;
        }

        public static double GetCellNumber(IXLWorksheet worksheet, string cell) 
        {
            if (worksheet.Cell(cell).GetString() != "") return Convert.ToDouble(worksheet.Cell(cell).GetString());
            return 0.0;
        }
    }
}
