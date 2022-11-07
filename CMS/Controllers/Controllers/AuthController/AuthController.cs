using CMS.JWT.AuthRepo;
using CMS.Models.Application;
using Microsoft.AspNetCore.Mvc;


namespace CMS.Controllers.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase, IAuthController
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