using CMS.Models.Application;
using CMS.Models.Shared;

namespace CMS.JWT.AuthRepo
{
    public interface IAuthRepository
    {
       
        AuthResult Authenticate(LoginModel credentials);
    }
}
