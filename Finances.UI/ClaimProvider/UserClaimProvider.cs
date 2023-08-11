using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Finances.UI.ClaimProvider
{
    public class UserClaimProvider : IClaimsTransformation
    {
        private readonly UserManager<AppUser> _userManager;

        public UserClaimProvider(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identityPrincipal = principal.Identity as ClaimsIdentity;
            var currentUser = await _userManager.FindByNameAsync(identityPrincipal.Name);
           
            if(currentUser.City != null)
            {
                if (principal.HasClaim(x => x.Type != "City"))
                {
                    Claim userClaim = new Claim("City",currentUser.City);
                    identityPrincipal.AddClaim(userClaim);
                }
            }
            return principal;
        }
    }
}
