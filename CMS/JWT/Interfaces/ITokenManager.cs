using CMS.Models.User;
using CMS.Models;

namespace CMS.JWT1.Interfaces
{
    public interface ITokenManager
    {
        AuthToken Generate(User user);
    }
}
