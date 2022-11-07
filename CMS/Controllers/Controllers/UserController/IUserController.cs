using CMS.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Controllers.Controllers.UserController
{
    public interface IUserController
    {
        public Task<List<User>> Get();
        public Task<IActionResult> Post(User newUser);
    }
}
