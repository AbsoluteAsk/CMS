using CMS.JWT.TokenServices;
using CMS.Models.Application;
using CMS.Models.Shared;

namespace CMS.JWT.AuthRepo
{
    public class ExtendedAuthRepository : AuthRepository
    {
        public ExtendedAuthRepository(ITokenManager tokenManager) : base(tokenManager)
        {
        }

        public override AuthResult Authenticate(LoginModel credentials)
        {
            return base.Authenticate(credentials);
        }
    }
}