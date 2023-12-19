using fin_back.Data.Entities;
using fin_back.Data;
using fin_back.Extensions;
using fin_back.Models.Organization;
using fin_back.Services.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using ClosedXML.Excel;
using fin_back.Models.Indicators;

namespace fin_back.Controllers
{
    [Route("organization/indicators")]
    [ApiController]
    public class OrganizationIndicatorsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public OrganizationIndicatorsController(ITokenService tokenService, DataContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrganizationIndicators(OrganizationIndicatorsCreate create)
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Unauthorized();

            string? authToken = Request.Headers.Authorization.ToString();

            if (AuthorizeValidation.TokenTimeValidation(authToken)) return Unauthorized();

            var user = await _userManager.FindByEmailAsync(AuthorizeValidation.GetTokenPayload(authToken).email);
            string? userToken = await _userManager.GetAuthenticationTokenAsync(user, "fin-back", "access-token");

            if (userToken != authToken) return Unauthorized();

            var b64balance = Convert.FromBase64String(create.BalanceFile.Split(',')[1]);
            var b64cashFlow = Convert.FromBase64String(create.CashFlowFile.Split(',')[1]);
            var b64profitNLoss = Convert.FromBase64String(create.ProfitNLossFile.Split(',')[1]);

            var indicators = CalculateIndicators.CalculateAllIndicators(new MemoryStream(b64balance), new MemoryStream(b64profitNLoss), new MemoryStream(b64cashFlow));

            var organizationIndicators = new OrganizationIndicators
            {
                Year = create.Year,
                RegNum = create.RegNum,
                LiquidityIndicators = indicators.LiquidityIndicators,
                FinancialIndicators = indicators.FinancialIndicators,
                ProfitabilityIndicators = indicators.ProfitabilityIndicators,
            };

            await _context.OrganizationIndicators.AddAsync(organizationIndicators);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("getByRegNum")]
        public async Task<IActionResult> GetOrganizationIndicatorsByRegNum(string RegNum)
        {
            var organizationIndicators = _context.OrganizationIndicators.Where(org => org.RegNum == Convert.ToInt32(RegNum)).ToList();

            return Ok(organizationIndicators);
        }

        [HttpPost("getByYear")]
        public async Task<IActionResult> GetOrganizationIndicatorsByYear(int Year)
        {
            var organizationIndicators = _context.OrganizationIndicators.Where(org => org.Year == Year).ToList();

            return Ok(organizationIndicators);
        }

        [HttpGet("getByRegNumAndYear")]
        public async Task<IActionResult> GetOrganizationIndicatorsByRegNumAndYear(string RegNum, string Year)
        {
            var orgInd = _context.OrganizationIndicators.Where(org => org.RegNum == Convert.ToInt32(RegNum) && org.Year == Convert.ToInt32(Year)).ToList()[0];



            var indicators = new Indicators
            {
                ProfitabilityIndicators = _context.ProfitabilityIndicators.Where(org => org.Id == orgInd.ProfitabilityIndicatorsId).ToList()[0],
                LiquidityIndicators =_context.LiquidityIndicators.Where(org => org.Id == orgInd.LiquidityIndicatorsId).ToList()[0],
                FinancialIndicators = _context.FinancialIndicators.Where(org => org.Id == orgInd.FinancialIndicatorsId).ToList()[0],
            };

            return Ok(indicators);
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(OrganizationIndicatorsCreate create)
        {
            var b64balance = Convert.FromBase64String(create.BalanceFile.Split(',')[1]);
            var b64cashFlow = Convert.FromBase64String(create.CashFlowFile.Split(',')[1]);
            var b64profitNLoss = Convert.FromBase64String(create.ProfitNLossFile.Split(',')[1]);

            var indicators = CalculateIndicators.CalculateAllIndicators(new MemoryStream(b64balance), new MemoryStream(b64profitNLoss), new MemoryStream(b64cashFlow));

            var organizationIndicators = new OrganizationIndicators
            {
                Year = create.Year,
                RegNum = create.RegNum,
                LiquidityIndicators = indicators.LiquidityIndicators,
                FinancialIndicators = indicators.FinancialIndicators,
                ProfitabilityIndicators = indicators.ProfitabilityIndicators,
            };

            await _context.OrganizationIndicators.AddAsync(organizationIndicators);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
