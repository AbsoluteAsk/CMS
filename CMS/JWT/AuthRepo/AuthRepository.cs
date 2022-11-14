using CMS.DAL.MongoDb;
using CMS.Database.CMSDb;
using CMS.Database.UserDb;
using CMS.Helpers;
using CMS.JWT.TokenServices;
using CMS.Models.Application;

using CMS.Models.Shared;
using System.Linq;

namespace CMS.JWT.AuthRepo
{/// <summary>
/// 
/// </summary>
    public class AuthRepository : IAuthRepository
    {
        private ITokenManager _tokenManager;
        readonly DbInitialization dbinit;
        UserService _userService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokenManager"></param>
        public AuthRepository(ITokenManager tokenManager, UserService userService)
        {
            _tokenManager = tokenManager;
            _userService = userService;

        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>


        public virtual AuthResult Authenticate(LoginModel credentials)
        {
          // var user = UserData.Users.FirstOrDefault(x => x.EmailAddress == credentials.Email);
            //uisng dbinit
           var user1 = _userService.GetMail(credentials.Email).Result;
          

            if (user1 != null)
            {
                return new AuthResult
                {
                    IsSuccess = true,
                    Token = _tokenManager.Generate(user1)
                };
            }

            return new AuthResult { IsSuccess = false };
        }
    }
}