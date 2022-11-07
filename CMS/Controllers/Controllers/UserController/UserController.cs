using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.Database.UserDb;
using CMS.Helpers;
using CMS.Models;
using CMS.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase, IUserController
    {
        private readonly UserService _userService;
        public UserController(UserService userService) =>
       _userService = userService;


        /// <summary>
        /// APi with policy and role based auth
        /// Role is supposed to be admin and email should be 1001 to be able to access otherwise forbidden error
        /// ShouldBeAuthorized  logic :- policy/reqirements/handlers
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Editor")]
        [Authorize("ShouldBeAuthorized")]
        [Route("all")]
        [HttpGet]
        public async Task<List<User>> Get() =>
        await _userService.GetAsync();



        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
            await _userService.CreateAsync(newUser);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }
    }
}