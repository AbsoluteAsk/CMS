using CMS.Models.User;
using CMS.Models.Shared;
using System.Threading.Tasks;

namespace CMS.JWT.TokenServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITokenManager
    {
        AuthToken Generate(User user);

    }
}
