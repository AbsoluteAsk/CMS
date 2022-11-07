using CMS.Models.User;
using CMS.Models.Shared;

namespace CMS.JWT.TokenServices
{
    public interface ITokenManager
    {
        AuthToken Generate(User user);
    }
}
