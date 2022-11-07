using CMS.Models.Application;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers.Controllers.AuthController
{
    public interface IAuthController
    {
        public IActionResult Validate(LoginModel model);
    }
}
