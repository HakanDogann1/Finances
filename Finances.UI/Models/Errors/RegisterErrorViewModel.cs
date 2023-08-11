using Microsoft.AspNetCore.Identity;

namespace Finances.UI.Models.Errors
{
    public class RegisterErrorViewModel:IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = "Parola kısa"
            };
        }
    }
}
