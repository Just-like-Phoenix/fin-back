using fin_back.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace fin_back.Services.Identity
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, List<IdentityRole<Guid>> role);
    }
}
