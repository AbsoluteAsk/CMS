

using CMS.JWT1.Interfaces;
using CMS.Models;

namespace CMS.JWT1.Providers
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