using CMS.Models.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Controllers.Controllers.CmsController
{
    public interface ICmsController
    {
        public Task<List<UserReq>> Get();
        public Task<IActionResult> Post(UserReq newCSR);

    }
}
