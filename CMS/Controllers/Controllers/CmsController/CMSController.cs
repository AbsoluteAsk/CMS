using CMS.Database.CMSDb;
using CMS.Database.UserDb;
using CMS.Models;
using CMS.Models.Application;
using CMS.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CMS.Controllers.Controllers.CmsController
{
    [ApiController]
    [Route("csr/[controller]")]
    public class CMSController : Controller, ICmsController
    {
        private readonly CMSService _cmsService;
        public CMSController(CMSService cmsService) =>
       _cmsService = cmsService;
        [HttpGet]
        public async Task<List<UserReq>> Get() =>
         await _cmsService.GetAsync();


        [HttpPost]
        public async Task<IActionResult> Post(UserReq newCSR)
        {
            await _cmsService.CreateAsync(newCSR);

            return CreatedAtAction(nameof(Get), new { id = newCSR.userId }, newCSR);
        }
    }
}
