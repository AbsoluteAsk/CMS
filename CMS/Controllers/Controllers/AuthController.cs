using CMS.JWT1.Interfaces;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;


namespace RolesAuthorize.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository repo)
        {
            _authRepository = repo;
        }

        [HttpPost]
        [Route("validate/1  ")]
        public IActionResult Validate(LoginModel model)
        {
            return Ok(_authRepository.Authenticate(model));
        }
    }
}