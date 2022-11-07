using CMS.DAL.MongoDb;
using CMS.Database.CMSDb;
using CMS.Database.UserDb;
using CMS.Helpers;
using CMS.JWT.TokenServices;
using CMS.Models.Application;

using CMS.Models.Shared;
using System.Linq;

namespace CMS.JWT.AuthRepo
{
    public class AuthRepository : IAuthRepository
    {
        private ITokenManager _tokenManager;
        readonly DbInitialization dbinit;
        UserService _userService;

        public AuthRepository(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;

        }



        public virtual AuthResult Authenticate(LoginModel credentials)
        {
            var user = UserData.Users.FirstOrDefault(x => x.EmailAddress == credentials.Email);
            //uisng dbinit
           // var user1 = _userService.GetMail(credentials.Email);

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