using Microsoft.AspNetCore.Identity;

namespace BDWalks.API.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
