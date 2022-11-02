using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers.Controllers
{
    public class CMSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
