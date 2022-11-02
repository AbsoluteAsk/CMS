using CMS.Database.UserDb;
using CMS.Helpers;
using CMS.JWT1.Interfaces;
using CMS.Models;
using System.Linq;

namespace CMS.JWT1.Providers
{
    public class AuthRepository : IAuthRepository
    {
        private ITokenManager _tokenManager;
        private readonly UserService _userService;

        public AuthRepository(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;

        }

        public virtual AuthResult Authenticate(LoginModel credentials)
        {
            var user = UserData.Users.FirstOrDefault(x => x.EmailAddress == credentials.Email);

            if (user != null)
            {
                return new AuthResult
                {
                    IsSuccess = true,
                    Token = _tokenManager.Generate(user)
                };
            }

            return new AuthResult { IsSuccess = false };
        }
    }
}