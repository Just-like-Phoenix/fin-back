using DocumentFormat.OpenXml.Office2016.Excel;
using fin_back.Data;
using fin_back.Data.Entities;
using fin_back.Extensions;
using fin_back.Models.Identity;
using fin_back.Models.Organization;
using fin_back.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace fin_back.Controllers
{
    [Route("organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public OrganizationController(ITokenService tokenService, DataContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrganization(OrganizationCreate organizationCreate)
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Unauthorized();

            string? authToken = Request.Headers.Authorization.ToString();

            if (AuthorizeValidation.TokenTimeValidation(authToken)) return Unauthorized();

            var user = await _userManager.FindByEmailAsync(AuthorizeValidation.GetTokenPayload(authToken).email);
            string? userToken = await _userManager.GetAuthenticationTokenAsync(user, "fin-back", "access-token");

            if (userToken != authToken) return Unauthorized();

            var organization = new Organization
            {
                ApplicationUser = user,
                RegNum = organizationCreate.RegNum,
                OrgType = organizationCreate.OrgType,
                OrgName = organizationCreate.OrgName,
                OrgEmail = organizationCreate.OrgEmail,
                OrgAddress = organizationCreate.OrgAddress
            };

            await _context.Organization.AddAsync(organization);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
