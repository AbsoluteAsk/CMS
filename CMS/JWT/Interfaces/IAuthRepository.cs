using CMS.Models;


namespace CMS.JWT1.Interfaces
{
    public interface IAuthRepository
    {
        AuthResult Authenticate(LoginModel credentials);
    }
}
