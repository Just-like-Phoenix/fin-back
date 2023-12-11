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
        public async Task<IActionResult> CreateOrganizationIndicators(OrganizationIndicatorsCreate organizationIndicators)
        {
/*            if (!Request.Headers.ContainsKey("Authorization"))
                return Unauthorized();

            string? authToken = Request.Headers.Authorization.ToString();

            if (AuthorizeValidation.TokenTimeValidation(authToken)) return Unauthorized();

            var user = await _userManager.FindByEmailAsync(AuthorizeValidation.GetTokenPayload(authToken).email);
            string? userToken = await _userManager.GetAuthenticationTokenAsync(user, "fin-back", "access-token");

            if (userToken != authToken) return Unauthorized();*/

            var balanceWS = new XLWorkbook(new MemoryStream(Convert.FromBase64String(organizationIndicators.BalanceFile))).Worksheet(1);
            var CurrentLiquidity = (CalculateIndicators.GetCellNumber(balanceWS, "G53") - CalculateIndicators.GetCellNumber(balanceWS, "G47")) / CalculateIndicators.GetCellNumber(balanceWS, "G92");
            //var CurrentLiquidity = (balanceWS.Cell("G53").GetDouble() - balanceWS.Cell("G47").GetDouble()) / balanceWS.Cell("G92").GetDouble();

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
