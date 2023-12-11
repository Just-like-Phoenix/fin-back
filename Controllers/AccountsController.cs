﻿using fin_back.Data.Entities;
using fin_back.Data;
using fin_back.Extensions;
using fin_back.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using fin_back.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace fin_back.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AccountsController(ITokenService tokenService, DataContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate(AuthRequest request)
        {
            ApplicationUser? managedUser = new ApplicationUser();
            ApplicationUser? user = new ApplicationUser();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            managedUser = await _userManager.FindByEmailAsync(request.Email);

            if (managedUser == null)
            {
                return Unauthorized();
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

            if (!isPasswordValid)
            {
                return Unauthorized();
            }


            user = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user is null)
                return Unauthorized();

            var roleIds = await _context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
            var roles = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

            var accessToken = _tokenService.CreateToken(user, roles);
            user.RefreshToken = _configuration.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:TokenValidityInDays").Get<int>());

            await _userManager.SetAuthenticationTokenAsync(user, "fin-back", "access-token", accessToken);

            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Email = user.Email!,
                Username = user.UserName!,
                FirstName = user.FirstName!, 
                LastName = user.LastName!, 
                MiddleName = user.MiddleName!,
                Token = accessToken,
                RefreshToken = user.RefreshToken
            });
        }
  
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Unauthorized();

            string? authToken = Request.Headers.Authorization.ToString();
            var user = await _userManager.FindByEmailAsync(AuthorizeValidation.GetTokenPayload(authToken).email);

            if (user == null) return Unauthorized();

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
            await _userManager.RemoveAuthenticationTokenAsync(user, "fin-back", "access-token");

            return Ok();
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(request);

            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            if (!result.Succeeded) return BadRequest(request);

            var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (findUser == null) throw new Exception($"User {request.Email} not found");

            await _userManager.AddToRoleAsync(findUser, RoleConsts.Member);

            return Ok();
        }


        /*[HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
        {
            if (tokenModel is null)
            {
                return BadRequest("Invalid client request");
            }

            var accessToken = tokenModel.AccessToken;
            var refreshToken = tokenModel.RefreshToken;
            var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);

            if (principal == null)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var username = principal.Identity!.Name;
            var user = await _userManager.FindByNameAsync(username!);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return BadRequest("Invalid access token or refresh token");
            }

            var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
            var newRefreshToken = _configuration.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }*/


        /*//for debug
        [HttpPost]
        [Route("tokentime")]
        public async Task<IActionResult> TokenTime()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Unauthorized();

            string? authToken = Request.Headers.Authorization.ToString();

            if (AuthorizeValidation.TokenTimeValidation(authToken)) return Unauthorized();

            var user = await _userManager.FindByEmailAsync(AuthorizeValidation.GetTokenPayload(authToken).email);
            string? userToken = await _userManager.GetAuthenticationTokenAsync(user, "fin-back", "access-token");

            if(userToken != authToken) return Unauthorized();

            return Ok(user.RefreshTokenExpiryTime);
        }*/
    }
}
